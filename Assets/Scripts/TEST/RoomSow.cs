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
    public RoomManagerSow Manager;

    public RoomState State; 

    public GameObject lightRoom;


    public bool activeRoom = false;//Lo ideal serai que sea un enum
    
    void Start()
    {
        Manager = FindAnyObjectByType<RoomManagerSow>();

        Manager.AddRoom(this);
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
        if(activeRoom)
        {
            lightRoom.SetActive(true);
        }
        else
        {
            lightRoom.SetActive(false);
        }
    }
}
