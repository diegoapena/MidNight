using System.Collections.Generic;
using UnityEngine;

// SoundManager controla TODOS los sonidos del juego.
// Usa un pool para sonidos múltiples y un método directo para reproducir un solo clip.
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip stepsPlayer;
    public AudioClip FlashLight;
    public AudioClip shadowAppearClip;

    public GameObject AudioReproducerPrefab;
    public int PoolSize = 10;
    public List<GameObject> AudioPool = new();

    public Dictionary<string, AudioClip> musicaData = new();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        // Crear pool
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject obj = Instantiate(AudioReproducerPrefab, transform);
            
            AudioPool.Add(obj);
        }
    }

    void Start()
    {

        musicaData.Add("stepplayer", stepsPlayer);
        musicaData.Add("flashlight", FlashLight);
        musicaData.Add("shadowAppear", shadowAppearClip);

        // PlaySound("stepplayer", 1f);
        //PlaySound("flashlight", 1f);
        //PlaySound("shadowAppear", 1f);

    }


    public void PlaySound(string musicName, float volume)
    {
        if (musicaData.TryGetValue(musicName, out AudioClip clip))
        {
            print(clip.name);


            AudioSource audioSource = GetAvalibleSoundReproducer().GetComponent<AudioSource>();

            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.gameObject.SetActive(true);
            audioSource.GetComponent<AudioReproducer>().SetAudio();
        }
        else
        {
            print(" no existe");
        }
    }



    public GameObject GetAvalibleSoundReproducer()
    {
        foreach (var item in AudioPool)
        {
            if (item.activeSelf == false)   
                return item;
        }
        Debug.Log("Se acabaron los sonidos disponibles");
        return null;
    }
}