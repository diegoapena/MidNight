using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public enum AnimationState
    {
        IdleRun,
        None
    }
    public static Player Instance;
    public InputSystem_Actions input;
    private Animator animator;
    private Vector2 moveInput;
    public float speed = 5f;
    public float Sanity = 100f;

    private IInteractable interactableObject;

    
    [SerializeField] private LinternaController linternaController;

    public AnimationState StateAnimation { get; private set; } = AnimationState.None;

    private void Awake()
    {
        input = new();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        input.Enable();

        input.Player.Move.started += OnMove;
        input.Player.Move.performed += OnMove;
        input.Player.Move.canceled += OnMove;

        
        input.Player.Linterna.started += OnLinterna;
    }

    private void OnDisable()
    {
        input.Player.Move.started -= OnMove;
        input.Player.Move.performed -= OnMove;
        input.Player.Move.canceled -= OnMove;

        input.Player.Linterna.started -= OnLinterna;

        input.Disable();
    }

    private void Update()
    {
        LuzCuartos();
        MovementMechanics();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (moveInput != Vector2.zero)
            StateAnimation = AnimationState.IdleRun;
    }

    private void MovementMechanics()
    {
        if (moveInput != Vector2.zero)
        {
            transform.position += (Vector3)moveInput * speed * Time.deltaTime;

            animator.SetFloat("Horizontal", moveInput.x);
            animator.SetFloat("Vertical", moveInput.y);
            animator.SetFloat("Speed", moveInput.magnitude);
        }
        else
        {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
        }
    }

    private void LuzCuartos()
    {
        if (interactableObject != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            interactableObject.Interact(gameObject);
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

    
    private void OnLinterna(InputAction.CallbackContext context)
    {
        if (linternaController == null)
        {
            Debug.LogError(" No hay LinternaController asignado.");
            return;
        }

        linternaController.ToggleLight();

        
    }
}