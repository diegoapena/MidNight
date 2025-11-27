using UnityEngine;

public class ShadowEnemy : BaseEnemy
{
    private bool isDead = false;

    void Start()
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

    public void DestroyEnemy()
    {
        Debug.Log($"{gameObject.name} destruido por la linterna.");
        Destroy(gameObject); // Destruir el objeto enemigo
    }
}