using UnityEngine;


public class RoomSow : MonoBehaviour
{
    // Este script controla el estado de las luces de una habitación.
    // Contiene referencias a dos luces (lightRoom y lightRoom1) y un booleano (activeRoom) que indica si la habitación está activa o no.
    // Permite alternar el estado de las luces con SwitchState() y actualizarlas con SetRoom().
    // Relación con otros scripts: 
    // Podría ser activado por un objeto interactivo (BaseInteractable) o por el jugador (Player) para encender o apagar las luces.

    public GameObject lightRoom;
    public GameObject lightRoom1;

    public bool activeRoom = false; // Estado actual de la habitación (encendida o apagada).

    // Alterna el estado de la habitación y actualiza las luces.
    public void SwitchState()
    {
        activeRoom = !activeRoom;
        SetRoom();
    }

    public void SetRoom()
    {
        try
        {
            if (lightRoom != null)
                lightRoom.SetActive(activeRoom);

            if (lightRoom1 != null)
                lightRoom1.SetActive(activeRoom);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al establecer el estado de la habitación: " + e.Message);
        }
    }
}