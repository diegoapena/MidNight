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
        source = GetComponent<AudioSource> ();
        
    }
    void Start()
    {
        
    }

    public void SetAudio()
    {
        Invoke("Desactiveobj", source.clip.length);
    }

    // Desactiva después de un tiempo específico
    public void SetAudio(float delay)
    {
        Invoke("Desactiveobj", delay);
    }

   
    public void SetAudio(AudioClip clip)
    {
        source.clip = clip;
        source.Play();
        Invoke("Desactiveobj", clip.length);
    }

    public void Desactiveobj()
    {
        gameObject.SetActive (false);
    }
}