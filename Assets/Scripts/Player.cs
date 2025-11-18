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

    public InputSystem_Actions input;
    private Animator animator;
    [SerializeField] private Vector2 moveInput;
    public float speed = 5f;
    public float Sanity = 100f;
    private IInteractable interactableObject;
    private Vector2 movementInput;
    public Action OnLinternaPerformed;

    [SerializeField] private RoomManager roomManager;
    [SerializeField] private GameObject linterna; // Referencia al objeto de la linterna
    private bool linternaEncendida = false; // Estado de la linterna

    // Definición para de StateAnimation
    public AnimationState StateAnimation { get; private set; } = AnimationState.None;

    private void Awake()
    {
        input = new();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Move.canceled += OnMove;
        input.Player.Move.performed += OnMove;
        input.Player.Move.started += OnMove;

        // Vincula la acción "Linterna"
        input.Player.Linterna.performed += OnLinterna;
    }

    private void OnDisable()
    {
        input.Player.Move.canceled -= OnMove;
        input.Player.Move.performed -= OnMove;
        input.Player.Move.started -= OnMove;

        // Desvincula la acción "Linterna"
        input.Player.Linterna.performed -= OnLinterna;

        input.Disable();

        animator.SetFloat("Horizontal", 3f);
        animator.SetFloat("Vertical", 3f);
        animator.SetFloat("Speed", 3f);
    }

    private void Update()
    {
        LuzCuartos();
        MovementMechanics();
    }
    private void LuzCuartos()
    {
        if (interactableObject != null && Input.GetKeyDown(KeyCode.E))
        {
            interactableObject.Interact(gameObject);
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();


        if (moveInput != Vector2.zero)
        {
            StateAnimation = AnimationState.IdleRun;
        }

    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IInteractable>() != null)
        {

            interactableObject = collision.gameObject.GetComponent<IInteractable>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        interactableObject = null;
    }

    public void MovementMechanics()
    {
        if (moveInput != Vector2.zero)
        {
            // Mover al personaje
            transform.position += (Vector3)moveInput * speed * Time.deltaTime;

            // Actualizar parámetros del Animator
            animator.SetFloat("Horizontal", moveInput.x);
            animator.SetFloat("Vertical", moveInput.y);
            animator.SetFloat("Speed", moveInput.magnitude);
        }
        else
        {
            // Detener animaciones si no hay movimiento
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
        }
    }

    private void OnLinterna(InputAction.CallbackContext context)
    {
        linternaEncendida = !linternaEncendida; // Alternar el estado de la linterna

        if (linterna != null)
        {
            linterna.SetActive(linternaEncendida); // Activar o desactivar la linterna
        }

        Debug.Log(linternaEncendida ? "Linterna encendida" : "Linterna apagada");
        OnLinternaPerformed?.Invoke();
    }
}
