using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShadowEnemy : BaseEntity
{
    private Transform player;
    public float detectionRange = 10f;
    public float speedMultiplier = 1.5f;

    private Light2D flashlight;
    private bool isDead = false;
    private BarraDeCordura barraCordura;

    protected new void Start()
    {
        base.Start();

        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        flashlight = FindFirstObjectByType<Light2D>();
        barraCordura = FindFirstObjectByType<BarraDeCordura>();

       
    }

    private void Update()
    {
        if (isDead || player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        // Persigue al jugador
        if (distance < detectionRange)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                (speed * speedMultiplier) * Time.deltaTime
            );
        }

        // Si la linterna lo apunta → muere
        if (flashlight != null && flashlight.enabled)
        {
            Vector2 dirToEnemy = (transform.position - flashlight.transform.position).normalized;
            float angle = Vector2.Angle(-flashlight.transform.up, dirToEnemy);

            if (angle < 30f && distance < flashlight.pointLightOuterRadius)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("💀 Shadow destruido por la linterna.");

        // Restaura la cordura al 100%
        if (barraCordura != null)
        {
            var playerScript = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>();
            if (playerScript != null)
                playerScript.Sanity = barraCordura.maxSanity;
        }

        Destroy(gameObject);
    }
}