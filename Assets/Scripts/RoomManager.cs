using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject[] rooms; // Referencia a los objetos Room
    private bool shadowSpawned = false;
    public Color color;

    public void Start()
    {
        color.a = 0; 
    }

    public void CheckAndSpawnShadow(float elapsedTime)
    {
        if (elapsedTime >= 60f && !shadowSpawned)
        {
            shadowSpawned = true;
            foreach (GameObject room in rooms)
            {
                Debug.Log($"Shadow spawned in room: {room.name}");
            }
        }
    }

    public void FadeRoomAlpha()
    {
        foreach (GameObject room in rooms)
        {
            if (room.TryGetComponent<SpriteRenderer>(out var spriteRenderer))
            {
                Color color = spriteRenderer.color;

                // Alternar el valor de alpha entre 0 y 1
                color.a = color.a == 0 ? 1 : 0;

                spriteRenderer.color = color;

                Debug.Log($"Alpha de la habitación {room.name} cambiado a {color.a}");
            }
        }
    }
}