using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioReproducer : MonoBehaviour
{
    AudioSource surce;

    public void Awake()
    {
        surce = GetComponent<AudioSource>();
    }

    void Start()
    {
        
    }
    public void SetAudio()
    {
        //surce.clip.length
        Invoke("DesactiveObj", surce.clip.length);
    }
    public void DesactiveObj()
    {
        gameObject.SetActive(false);    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
