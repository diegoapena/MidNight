using UnityEngine;

public class CamaraPlayer : MonoBehaviour
{
    public GameObject Player; // Referencia al jugador
    public float Speed = 2f; // Velocidad de interpolación de la cámara
    public float OffsetDistance = 3f; // Distancia de desplazamiento de la cámara cuando el jugador se mueve

    private Vector3 lastPlayerPosition; // Posición del jugador en el último frame
    private Vector3 movementDirection; // Dirección del movimiento del jugador

    void Start()
    {
        // Inicializar la posición del jugador
        lastPlayerPosition = Player.transform.position;
    }

    void Update()
    {
        UpdateMovementDirection();
        CamaraPlayerLerp();
    }

    private void UpdateMovementDirection()
    {
        // Calcular la dirección del movimiento del jugador
        Vector3 currentPlayerPosition = Player.transform.position;
        movementDirection = (currentPlayerPosition - lastPlayerPosition).normalized;

        // Actualizar la última posición del jugador
        lastPlayerPosition = currentPlayerPosition;
    }

    private void CamaraPlayerLerp()
    {
        // Calcular la posición objetivo de la cámara
        Vector3 targetPosition;

        if (movementDirection != Vector3.zero)
        {
            // Si el jugador se está moviendo, posicionar la cámara ligeramente por delante
            targetPosition = Player.transform.position + movementDirection * OffsetDistance;
        }
        else
        {
            // Si el jugador está detenido, centrar la cámara en el jugador
            targetPosition = Player.transform.position;
        }

        // Mantener la posición Z de la cámara
        targetPosition.z = transform.position.z;

        // Interpolar suavemente hacia la posición objetivo
        transform.position = Vector3.Lerp(transform.position, targetPosition, Speed * Time.deltaTime);
    }
}
