using UnityEngine;

public class ShadowEnemy : BaseEnemy
{
    private bool isDead = false;

    void Start()
    {
        base.Start();
        DamageSanityOnSpawn();

        // reproducir sonido al aparecer
        PlayAppearSound();
    }

    private void PlayAppearSound()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlaySoundFromPool("shadowAppear", 1f);
        }
    }

    private void DamageSanityOnSpawn()
    {
        BarraDeCordura.Instance?.IniciarBajadaCordura();
        Debug.Log("Shadow apareció: comienza bajada de cordura");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;
        if (collision.gameObject.CompareTag("Player")) Attack();
    }

    public void Attack()
    {
        if (isDead) return;
        BarraDeCordura.Instance?.IniciarBajadaCordura();
        Debug.Log("Shadow atacó: tu cordura bajará");
        Die();
    }

    public void TakeDamage(float amount) => Die();
    public void Die()
    {
        if (isDead) return;
        isDead = true;
        Destroy(gameObject);
    }

    public void DieByLight() => Die();
    public void DestroyEnemy()
    {
        Debug.Log($"{gameObject.name} destruido por la linterna.");
        Destroy(gameObject);

        if (isDead) return;
        isDead = true;


        if (BarraDeCordura.Instance != null)
        {
            BarraDeCordura.Instance.RestaurarCordura();
        }

        Debug.Log("Shadow muerto — Cordura restaurada al 100.");

        Destroy(gameObject);
    }

}