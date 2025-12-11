using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip stepsPlayer;
    public AudioClip FlashLight;
    public AudioClip shadowAppearClip;
    public AudioClip PollulantAppearClip;
    public AudioClip ShapeShifterAppearClip;
    public GameObject AudioReproducerPrefab;
    
    public int PoolSize = 10;
    public List<GameObject> AudioPool = new();
    public Dictionary<string, AudioClip> musicaData = new();

    private GameObject playerStepObj; // objeto reservado para pasos
    private AudioSource playerStepSource;

    private void Awake()
    {
        if (Instance == null) Instance = this;

        // Crear pool
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject obj = Instantiate(AudioReproducerPrefab, transform);
            obj.SetActive(false);
            AudioPool.Add(obj);
        }

        // Reservar objeto del pool solo para pasos del Player
        if (AudioPool.Count > 0)
        {
            playerStepObj = AudioPool[0];
            playerStepSource = playerStepObj.GetComponent<AudioSource>();
            playerStepSource.clip = stepsPlayer;
            playerStepSource.loop = true; // loop para pasos continuos
            playerStepSource.volume = 1f;
            playerStepObj.SetActive(false);
        }
    }

    void Start()
    {
        musicaData.Add("stepplayer", stepsPlayer);
        musicaData.Add("flashlight", FlashLight);
        musicaData.Add("shadowAppear", shadowAppearClip);
        musicaData.Add("PollulantAppear", PollulantAppearClip);
        musicaData.Add("ShapeShifterAppear", ShapeShifterAppearClip);
    }

    // --- Métodos para pasos del Player ---
    public void PlayPlayerStep()
    {
        if (playerStepObj == null || playerStepSource.isPlaying) return;

        playerStepObj.SetActive(true);
        playerStepSource.Play();
    }

    public void StopPlayerStep()
    {
        if (playerStepObj == null) return;

        if (playerStepSource.isPlaying)
        {
            playerStepSource.Stop();
            playerStepObj.SetActive(false);
        }
    }

    // --- Otros sonidos ---
    public void PlaySound(string musicName, float volume)
    {
        if (musicaData.TryGetValue(musicName, out AudioClip clip))
        {
            GameObject obj = GetAvalibleSoundReproducer();
            if (obj == null) return; // Si no hay objetos disponibles, salimos del método

            AudioSource audioSource = obj.GetComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = volume;
            obj.SetActive(true); // Activamos el objeto del pool para que se ejecute en la escena
            obj.GetComponent<AudioReproducer>().SetAudio();
        }
        else
        {
            print("no existe");
        }
    }

    public GameObject GetAvalibleSoundReproducer()
    {
        foreach (var item in AudioPool)
        {
            if (!item.activeSelf && item != playerStepObj)
                return item;
        }
        Debug.Log("Se acabaron los sonidos disponibles");
        return null;
    }
}