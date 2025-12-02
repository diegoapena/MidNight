// Este script define un objeto interactivo básico.
// Contiene un tooltip que se muestra al acercarse y un evento UnityEvent que se invoca al interactuar.
// Relación con otros scripts:
// Se relaciona con Player, ya que el jugador puede interactuar con estos objetos.
// Podría usarse para activar RoomSow o cualquier otro objeto interactivo.

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
    }

    public void OnPlayerExit()
    {
    }
}
