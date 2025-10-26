using UnityEngine;

public class Puertas : MonoBehaviour, IInteractable
{
    public GameObject pressEText;

    void Start()
    {
        if (pressEText != null)
            pressEText.SetActive(false); // Solo oculta el texto, no la puerta
    }

    public void OnPlayerEnter()
    {
        if (pressEText != null)
            pressEText.SetActive(true);
    }

    public void OnPlayerExit()
    {
        if (pressEText != null)
            pressEText.SetActive(false);
    }

    public void Interact(GameObject observer)
    {
        Debug.Log(observer.name + " ha interactuado con la door xd");
      
    }
}