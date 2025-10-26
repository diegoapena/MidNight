using UnityEngine;


public interface IInteractable
{
    void Interact(GameObject observer);
    void OnPlayerEnter();
    void OnPlayerExit();
}
