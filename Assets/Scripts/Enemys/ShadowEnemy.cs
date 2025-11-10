using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShadowEnemy : BaseEntity
{
    private bool isDead = false;

    protected override void Start()
    {
        base.Start();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            Die();
        }
    }

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("💀 Shadow murió.");

        
        var player = FindFirstObjectByType<Player>();
        var barra = FindFirstObjectByType<BarraDeCordura>();

        if (player != null && barra != null)
        {
            player.Sanity = barra.maxSanity;
            Debug.Log("✨ Cordura regenerada al máximo.");
        }

        Destroy(gameObject);
    }

    public void DieByLight()
    {
        
        Die();
    }
}