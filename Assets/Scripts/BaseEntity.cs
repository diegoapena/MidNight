using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] protected float speed = 2f;
    [SerializeField] protected float health = 100f;
    [SerializeField] protected float damage = 10f;
    [SerializeField] protected string entityName = "Entity";

    protected Rigidbody2D rb;
    protected Animator anim;
    protected SpriteRenderer sprite;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

protected virtual void Die()
    {
        
        Debug.Log($"{gameObject.name} ha muerto (BaseEntity)");
        Destroy(gameObject);
    }
}