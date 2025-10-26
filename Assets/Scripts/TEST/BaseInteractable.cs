using UnityEngine;
using UnityEngine.Events;

public class BaseInteractable : MonoBehaviour, IInteractable
{
    public UnityEvent OnInteractTest = new ();
    void Start()
    {

    }

    public void Interact(GameObject observer)
    {
        OnInteractTest.Invoke();
        print("Triggerr");
    }

    public void OnPlayerEnter()
    {
       // throw new System.NotImplementedException();
    }

    public void OnPlayerExit()
    {
       // throw new System.NotImplementedException();
    }
 
}
    
