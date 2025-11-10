using UnityEngine;

public enum RoomState
{
    None,
    LightOn,
    LightOff,
    Haunted
}

public class RoomSow : MonoBehaviour
{
    [Header("References")]
    public RoomManager Manager;

    public RoomState State;

    public GameObject lightRoom;

    public bool activeRoom = false; // Lo ideal sería que sea un enum

    void Start()
    {
        // Usar FindFirstObjectByType en vez de FindObjectOfType (no obsoleto)
        Manager = Object.FindFirstObjectByType<RoomManager>();

        if (Manager != null)
        {
            Manager.AddRoom(this);
        }
        else
        {
            Debug.LogError("RoomManager no encontrado en la escena.");
        }
    }

    public void SwitchState()
    {
        activeRoom = !activeRoom;
        SetRoom();
    }

    public void SetRoom()
    {
        switch (State)
        {
            case RoomState.None:
                // Implementar si hace falta
                break;
            case RoomState.LightOn:
                // Implementar si hace falta
                break;
            case RoomState.LightOff:
                // Implementar si hace falta
                break;
            case RoomState.Haunted:
                // Implementar si hace falta
                break;
            default:
                break;
        }

        // Activar/desactivar la luz de la habitación de forma segura
        if (lightRoom != null)
            lightRoom.SetActive(activeRoom);
        else
            Debug.LogWarning($"RoomSow ({name}): lightRoom no asignado en el Inspector.");
    }
}