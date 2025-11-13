using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LinternaController : MonoBehaviour
{
    public Light2D flashlight; // Referencia al componente Light2D de la linterna
    public float rotationSpeed = 8f; // Velocidad de rotación de la linterna
    private bool isOn = false; // Estado de la linterna (encendida o apagada)

    void Update()
    {
        RotateTowardsMouse(); // Hacer que la linterna apunte hacia el mouse

       
    }

    private void RotateTowardsMouse()
    {
        // Obtener la posición del mouse en el mundo
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Asegurarse de que la posición Z sea 0 para 2D

        // Calcular la dirección hacia el mouse
        Vector3 direction = (mousePosition - flashlight.transform.position).normalized;

        // Calcular el ángulo hacia el mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotar la linterna suavemente hacia el ángulo calculado
        flashlight.transform.rotation = Quaternion.Lerp(
            flashlight.transform.rotation,
            Quaternion.Euler(0, 0, angle - 90f),
            Time.deltaTime * rotationSpeed
        );

        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn; // Alternar el estado de la linterna
            flashlight.enabled = isOn; // Activar o desactivar la luz
        }
    }
}