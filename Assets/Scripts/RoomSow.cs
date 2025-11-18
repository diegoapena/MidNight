using UnityEngine;


public class RoomSow : MonoBehaviour
{
    [Header("References")]
    public RoomManager Manager;

    public GameObject lightRoom;
    public GameObject lightRoom1;

    public bool activeRoom = false; // Lo ideal sería que sea un enum

    void Start()
    {
        Manager = Object.FindFirstObjectByType<RoomManager>();

        if (Manager != null)
        {
            Manager.AddRoom(this);
        }
    }
     

    public void SwitchState()
    {
        activeRoom = !activeRoom;
        SetRoom();
    }

    public void SetRoom()
    {
       
        if (lightRoom != null)
            lightRoom.SetActive(activeRoom);
        else
            Debug.LogWarning($"RoomSow ({name})");
        if (lightRoom1 != null)
            lightRoom1.SetActive(activeRoom);
        else
            Debug.LogWarning($"RoomSow ({name})");
    }
}