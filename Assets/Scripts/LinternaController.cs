using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LinternaController : MonoBehaviour
{
    public Light2D flashlight;
    public float rotationSpeed = 8f;
    private bool isOn = false;

    [SerializeField] private float detectionAngle = 0.8f; // Umbral del producto punto para detectar enemigos
    [SerializeField] private float detectionRange = 5f; // Rango de detección de la linterna
    [SerializeField] private BarraDeCordura barraDeCordura; // Referencia a la barra de cordura

    public void ToggleLight()
    {
        isOn = !isOn;
        flashlight.enabled = isOn;
        Debug.Log(isOn ? "Linterna encendida" : "Linterna apagada");
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
                    enemy.DestroyEnemy(); // Destruir al enemigo
                    barraDeCordura.RestaurarCordura(); // Restaurar la cordura
                }
            }
        }
    }
}