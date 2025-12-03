using UnityEngine;

// Este script controla la reproducción de clips de audio y desactiva el objeto una vez que el clip termina.
// Relación con otros scripts:
// Es utilizado por SoundManager para reproducir sonidos desde un pool de objetos.
[RequireComponent(typeof(AudioSource))]
public class AudioReproducer : MonoBehaviour
{
    AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void SetAudio()
    {
        source.Play(); 
        Invoke("Desactiveobj", source.clip.length);
    }

    public void Desactiveobj()
    {
        gameObject.SetActive(false);
    }
}