using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip stepsPlayer;
    public AudioClip FlashLight;

    public Dictionary<string, AudioClip> musicaData = new ();
    public GameObject AudioReproducerPrefab;
    public int PoolSize = 10;
    public List<GameObject> AudioPool = new ();

    private void Awake()
    {
       if(Instance == null)
            Instance = this;

       for(int i = 0; i < PoolSize; i++)
       {
            GameObject obj = Instantiate(AudioReproducerPrefab);
            
            AudioPool.Add(obj);
        }
    }

    void Start()
    {
        musicaData.Add("stepplayer", stepsPlayer);
        musicaData.Add("FlashLight", FlashLight);

        PlaySound("stepplayer", 10);
        PlaySound("FlashLight", 5);
    }
    public void PlaySound(string musicName, float volume)
    {
        if (musicaData.TryGetValue(musicName, out AudioClip clip))
        {
            print(clip.name);
            AudioSource audioSource = GetAvalibSoundReproducer().GetComponent<AudioSource>();

            audioSource.volume = volume;
            audioSource.clip = clip;
            audioSource.gameObject.SetActive(true);
            audioSource.GetComponent<AudioReproducer>().SetAudio();


        }
        else
        {
            print("no existe");
        }
    }
    public GameObject GetAvalibSoundReproducer()
    {
        foreach (var item in AudioPool)
        {
            if (item.activeSelf == true)
                return item;
        }
        return null;

    }
    
}
