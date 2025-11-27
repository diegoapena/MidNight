using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float Sanity = 100f;
    public static Player Instance;  

    private PlayerInputs inputs;
    private PlayerAnimation anim;

    private IInteractable interactableObject;

    [SerializeField] private LinternaController linternaController;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        inputs = GetComponent<PlayerInputs>();
        anim = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        HandleMovement();
        HandleInteraction();
        HandleLinterna();
    }

    private void HandleMovement()
    {
        Vector2 input = inputs.MoveInput;

        if (input != Vector2.zero)
        {
            transform.position += (Vector3)input * speed * Time.deltaTime;
            anim.UpdateMovementAnimation(input);
        }
        else
        {
            anim.StopMovementAnimation();
        }
    }

    private void HandleInteraction()
    {
        if (interactableObject != null && inputs.InteractPressed)
        {
            interactableObject.Interact(gameObject);
        }
    }

    private void HandleLinterna()
    {
        if (inputs.LinternaPressed)
        {
            if (linternaController == null)
            {
                Debug.LogError("No hay LinternaController asignado.");
            }
            else
            {
                linternaController.ToggleLight();
            }

            inputs.ClearLinterna();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interact))
        {
            interactableObject = interact;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        interactableObject = null;
    }
}