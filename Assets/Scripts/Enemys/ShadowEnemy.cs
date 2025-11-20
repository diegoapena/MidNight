using UnityEngine;

public class ShadowEnemy : BaseEntity, IEnemy, IDamageable
{
    [Header("Daño de cordura")]
    public float sanityDamage = 20f; // YA NO SE USA, LO PUEDES ELIMINAR

    private bool isDead = false;

    protected override void Start()
    {
        base.Start();
        DamageSanityOnSpawn();
    }
    public void ChasePlayer()
    {
        
    }

    public void StopChasing()
    {
        
    }

    
    private void DamageSanityOnSpawn()
    {
        BarraDeCordura.Instance?.IniciarBajadaCordura();
        Debug.Log("Shadow apareció  comienza bajada continua de cordura");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (isDead) return;

        
        BarraDeCordura.Instance?.IniciarBajadaCordura();
        Debug.Log("Shadow atacó  tu cordura bajara");

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
        Destroy(gameObject);
    }

    public void DieByLight()
    {
        Die();
    }
}