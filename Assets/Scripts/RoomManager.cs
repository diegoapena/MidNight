using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private List<RoomSow> roomList = new List<RoomSow>();

    void Start()
    {

    }

    public void AddRoom(RoomSow room)
    {
        if (!roomList.Contains(room))
        {
            roomList.Add(room);
          
        }
    }
}
