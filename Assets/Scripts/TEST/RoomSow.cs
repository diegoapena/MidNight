using UnityEngine;




public class RoomSow : MonoBehaviour
{
    [Header("References")]
    public RoomManagerSow Manager;
    public GameObject Tooltip;

    public GameObject lightRoom;

    public bool LightIsOn;
    
    void Start()
    {
        Manager = FindAnyObjectByType<RoomManagerSow>();
        Tooltip.SetActive(false);

        Manager.AddRoom(this);
    }
   
    public void OpenRoom()
    {
        LightIsOn = lightRoom ? true: false;    
        
    }
    public void SetRoom()
    {

    }
}
