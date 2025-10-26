using UnityEngine;




public class RoomSow : MonoBehaviour
{
    [Header("References")]
    public RoomManagerSow Manager;

    public GameObject lightRoom;

    public bool activeRoom = false;
    
    void Start()
    {
        Manager = FindAnyObjectByType<RoomManagerSow>();

        Manager.AddRoom(this);
    }
   
    public void SwitchState()
    {
        activeRoom = !lightRoom;
        SetRoom();


    }
    public void SetRoom()
    {
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
