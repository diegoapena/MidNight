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
        // Cambiado a FindObjectOfType para evitar errores
        Manager = FindObjectOfType<RoomManager>();

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
                break;
            case RoomState.LightOn:
                
                break;
            case RoomState.LightOff:
                break;
            case RoomState.Haunted:
                break;
            default:
                break;
        }
        if (activeRoom)
        {
            lightRoom.SetActive(true);
        }
        else
        {
            lightRoom.SetActive(false);
        }
    }
}