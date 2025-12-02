using UnityEngine;


public class RoomSow : MonoBehaviour
{
    // Este script controla el estado de las luces de una habitación.
    // No tiene herencias ni interfaces implementadas.
    // Puede relacionarse con el jugador o un objeto interactivo para encender o apagar las luces.

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
       
        if (lightRoom != null)
            lightRoom.SetActive(activeRoom);
       
        if (lightRoom1 != null)
            lightRoom1.SetActive(activeRoom);
       
    }
}