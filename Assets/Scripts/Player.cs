using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public InputSystem_Actions input;
    [SerializeField] private Vector2 moveInput;
    public float speed = 5f;
    private IInteractable interactableObject;
    public GameObject InteractText;
    [SerializeField] private RoomManager roomManager;

    private void OnEnable()
    {
        input.Enable();
        input.Player.Move.canceled += OnMove;
        input.Player.Move.performed += OnMove;
        input.Player.Move.started += OnMove;
    }

    private void OnDisable()
    {
        input.Player.Move.canceled -= OnMove;
        input.Player.Move.performed -= OnMove;
        input.Player.Move.started -= OnMove;
        input.Disable();
    }

    private void Awake()
    {
        input = new();
    }

    private void Update()
    {
        transform.position += (Vector3)moveInput * speed * Time.deltaTime;

        if (interactableObject != null && Input.GetKeyDown(KeyCode.E))
        {
            interactableObject.Interact(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IInteractable>() != null)
        {
            InteractText.SetActive(true);
            interactableObject = collision.gameObject.GetComponent<IInteractable>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        InteractText.SetActive(false);
        interactableObject = null;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
