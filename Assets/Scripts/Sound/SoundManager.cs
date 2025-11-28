using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip stepsPlayer;
    public AudioClip FlashLight;
    public AudioClip shadowAppearClip;

    public GameObject AudioReproducerPrefab;
    public int PoolSize = 10;
    public List<GameObject> AudioPool = new();

    private AudioSource stepAudioSource;

    private void Awake()
    {
        if (Instance == null) Instance = this;

        // AudioSource dedicado para pasos
        stepAudioSource = gameObject.AddComponent<AudioSource>();
        stepAudioSource.clip = stepsPlayer;
        stepAudioSource.loop = true;
        stepAudioSource.playOnAwake = false;

        // Inicializar pool
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject obj = Instantiate(AudioReproducerPrefab);
            obj.SetActive(false);
            AudioPool.Add(obj);
        }
    }

    private void Start()
    {
        // registrar clips en el diccionario
        musicaData.Add("stepplayer", stepsPlayer);
        musicaData.Add("FlashLight", FlashLight);
        if (shadowAppearClip != null)
            musicaData.Add("shadowAppear", shadowAppearClip);
    }

    public Dictionary<string, AudioClip> musicaData = new();

    // --- Pasos del Player ---
    public void PlayStepSound()
    {
        if (!stepAudioSource.isPlaying)
            stepAudioSource.Play();
    }

    public void StopStepSound()
    {
        if (stepAudioSource.isPlaying)
            stepAudioSource.Stop();
    }

    // --- Pool para otros sonidos ---
    public void PlaySoundFromPool(string musicName, float volume)
    {
        if (!musicaData.TryGetValue(musicName, out AudioClip clip)) return;

        List<GameObject> available = new List<GameObject>();
        foreach (var obj in AudioPool)
            if (!obj.activeSelf) available.Add(obj);

        if (available.Count == 0) return;

        GameObject audioObj = available[Random.Range(0, available.Count)];
        AudioSource audioSource = audioObj.GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioObj.SetActive(true);
        audioObj.GetComponent<AudioReproducer>().SetAudio();
    }

    public void StopSound(string musicName)
    {
        if (!musicaData.TryGetValue(musicName, out AudioClip clip)) return;

        foreach (var obj in AudioPool)
        {
            AudioSource src = obj.GetComponent<AudioSource>();
            if (src.clip == clip)
            {
                src.Stop();
                obj.SetActive(false);
            }
        }
    }
}