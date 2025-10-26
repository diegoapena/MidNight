using System.Collections.Generic;
using UnityEngine;

public class RoomManagerSow : MonoBehaviour
{
    [SerializeField] private List<RoomSow> roomList;
    void Start()
    {

    }

    public void AddRoom(RoomSow room)
    {
        roomList.Add(room);
    }
}
