using UnityEngine;

using System.Collections;

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