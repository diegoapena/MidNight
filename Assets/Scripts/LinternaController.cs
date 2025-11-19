using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LinternaController : MonoBehaviour
{
    public Light2D flashlight;
    public float rotationSpeed = 8f;
    private bool isOn = false;

    public void ToggleLight()
    {
        isOn = !isOn;
        flashlight.enabled = isOn;
        Debug.Log(isOn ? "Linterna encendida" : "Linterna apagada");
    }

    void Update()
    {
        RotateTowardsMouse();
    }

    private void RotateTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = (mousePosition - flashlight.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        flashlight.transform.rotation = Quaternion.Lerp(
            flashlight.transform.rotation,
            Quaternion.Euler(0, 0, angle - 90f),
            Time.deltaTime * rotationSpeed
        );
    }
}