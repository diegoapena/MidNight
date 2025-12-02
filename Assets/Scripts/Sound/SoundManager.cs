using System.Collections.Generic;
using UnityEngine;
// Este script gestiona los sonidos del juego.
// Contiene un pool de objetos para reproducir clips de audio y métodos para reproducir o detener sonidos.
// Relación con otros scripts:
// Se relaciona con Player (sonidos de pasos), LinternaController (sonido de linterna) y enemigos (sonidos al aparecer o atacar).
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip stepsPlayer;
    public AudioClip FlashLight;
    public AudioClip shadowAppearClip;

    public GameObject AudioReproducerPrefab;
    public int PoolSize = 10;
    public List<GameObject> AudioPool = new();

    public Dictionary<string, AudioClip> musicData = new();
   

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

    }

   void Start()
    {
        // registrar clips en el diccionario
        musicaData.Add("stepplayer", stepsPlayer);
        musicaData.Add("FlashLight", FlashLight);
            musicaData.Add("shadowAppear", shadowAppearClip);

        PlaySound("steppplayer", 10);
        PlaySound("Flashlight", 10);
        PlaySound("shadowAppear", 10);
    }

    public Dictionary<string, AudioClip> musicaData = new();

    // --- Pasos del Player ---
    public void PlaySound(string musicName, float volume)
    {
        if (musicaData.TryGetValue(musicName, out AudioClip clip))
        {
            print(clip.name);

            AudioSource AudioSource = AudioReproducerPrefab.GetComponent<AudioSource>();

            AudioSource.clip = clip;
            AudioSource.volume = volume;
            AudioReproducerPrefab.SetActive(true);
        }
        else
        {
            print(" no existe");
        }
    }

    public void StopStepSound()
    {
        if (stepAudioSource.isPlaying)
            stepAudioSource.Stop();
    }

    
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