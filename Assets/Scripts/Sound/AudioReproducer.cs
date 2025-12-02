using UnityEngine;

using System.Collections;
// Este script controla la reproducción de clips de audio y desactiva el objeto una vez que el clip termina.
// Relación con otros scripts:
// Es utilizado por SoundManager para reproducir sonidos desde un pool de objetos.
public class AudioReproducer : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            Debug.LogError("AudioSource no encontrado en AudioReproducer");
    }

    public void SetAudio()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
            StartCoroutine(DisableAfterClip());
        }
    }

    private IEnumerator DisableAfterClip()
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        audioSource.Stop();
        gameObject.SetActive(false);
    }
}