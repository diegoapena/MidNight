using UnityEngine;
using UnityEngine.Events;

public class BaseInteractable : MonoBehaviour, IInteractable
{
    public GameObject tooltip;
    public UnityEvent OnInteractTest;



    void Start()
    {
        tooltip.SetActive(false);
    }

    public void Interact(GameObject observer)
    {
        OnInteractTest.Invoke();
        print("Triggerr");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tooltip.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        tooltip.SetActive(false);
    }

    public void OnPlayerEnter()
    {
        throw new System.NotImplementedException();
    }

    public void OnPlayerExit()
    {
        throw new System.NotImplementedException();
    }
}
    
