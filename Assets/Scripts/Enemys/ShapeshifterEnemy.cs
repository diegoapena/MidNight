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

        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }
}