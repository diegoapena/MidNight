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
        isDead = true;

        Debug.Log($"{gameObject.name} destruido por la linterna.");
        Destroy(gameObject);
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
        Destroy(gameObject);
    }

}