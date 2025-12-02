using UnityEngine;

public class ShapeshifterEnemy : MonoBehaviour
{
    private bool isDead = false;

    void Start()
    {

    }

    public void DestroyEnemy()
    {
        if (isDead) return;

        Debug.Log($"{gameObject.name} destruido por la linterna.");

        Die();
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
        Debug.Log("Shapeshifter apararecio tu cordura bajará");
        Die();
    }
    public void TakeDamage(float amount) => Die();
    public void Die()
    {
        if (isDead) return;
        isDead = true;

        
        if (BarraDeCordura.Instance != null)
        {
            BarraDeCordura.Instance.RestaurarCordura();
        }

        Debug.Log("Shapeshifter muerto — Cordura restaurada al 100.");

        Destroy(gameObject);
    }



}