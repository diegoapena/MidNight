using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ShadowEnemy : BaseEntity, IEnemy, IDamageable
{
    [Header("Daño de cordura")]
    public float sanityDamage = 20f;

    private bool isDead = false;
    public static BarraDeCordura Instance;
    protected override void Start()
    {
        base.Start();
        DamageSanityOnSpawn();
    }

    // Baja cordura cuando aparece
    private void DamageSanityOnSpawn()
    {
        if (BarraDeCordura.Instance != null)
        {
            BarraDeCordura.Instance.RestarCordura(sanityDamage);
            Debug.Log($"Shadow apareció tu cordura -{sanityDamage}");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            Attack();
        }
    }

    public void ChasePlayer()
    {
       
    }

    public void StopChasing()
    {
       
    }

    public void Attack()
    {
        if (isDead) return;

        if (BarraDeCordura.Instance != null)
        {
            BarraDeCordura.Instance.RestarCordura(sanityDamage);
            Debug.Log($"Shadow atacó → cordura -{sanityDamage}");
        }

        Die();
    }

    public void TakeDamage(float amount)
    {
        Die();
    }

    public void Die()
    {
        if (isDead) return;

        isDead = true;
        Debug.Log("Shadow murió.");

        Destroy(gameObject);
    }

    public void DieByLight()
    {
        Die();
    }
}