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
        if (!roomList.Contains(room)) // condición que nos ayuda a comprobar si el objeto room que se intenta agregar ya existe dentro de roomList
        {
            roomList.Add(room);
          
        }
    }
}
