using UnityEngine;
using UnityEngine.Rendering.Universal;
// Este script controla la linterna del jugador.
// Permite encenderla, rotarla hacia el mouse y detectar enemigos dentro de su rango.
// Relación con otros scripts:
// Se relaciona con Player, que lo controla.
// Puede destruir enemigos como ShadowEnemy y ShapeshifterEnemy.
// Utiliza SoundManager para reproducir el sonido de la linterna.
public class LinternaController : MonoBehaviour
{
    public Light2D flashlight;
    private float rotationSpeed = 8f;
    private bool isOn = false;
    [SerializeField] private float detectionAngle = 0.8f;
    [SerializeField] private float detectionRange = 5f;
    
    public void ToggleLight()
    {
        isOn = !isOn;
        flashlight.enabled = isOn;
        Debug.Log(isOn ? "Linterna encendida" : "Linterna apagada");

        // Reproducir sonido solo al encender
        SoundManager.Instance.PlaySound("flashlight", 5);
    }

    void Update()
    {
        RotateTowardsMouse();
        if (isOn)
        {
            DetectEnemies();
        }
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

    private void DetectEnemies()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(flashlight.transform.position, detectionRange);
        foreach (var hitCollider in hitColliders)
        {
            var enemy = hitCollider.GetComponent<BaseEnemy>();
            if (enemy != null)
            {
                Vector3 enemyDir = (enemy.transform.position - flashlight.transform.position).normalized;
                Vector3 flashlightDir = flashlight.transform.up;

                float dot = Vector3.Dot(flashlightDir, enemyDir);
                if (dot > detectionAngle)
                {
                    enemy.DestroyEnemy();
                    
                }
            }
        }
    }
}