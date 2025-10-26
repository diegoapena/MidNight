using UnityEngine;

public class RoomSow : MonoBehaviour ,IInteractable
{
    [Header("References")]
    public RoomManagerSow Manager;
    public GameObject Tooltip;

    public GameObject lightRoom;
    
    void Start()
    {
        Manager = FindAnyObjectByType<RoomManagerSow>();
        Tooltip.SetActive(false);

        Manager.AddRoom(this);
    }
    public void Interact(GameObject observer)
    {
        lightRoom.SetActive(true);
    }

    public void OnPlayerEnter()
    {
        throw new System.NotImplementedException();
    }

    public void OnPlayerExit()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Player")
            Tooltip.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Tooltip.SetActive(false);

    }

}
