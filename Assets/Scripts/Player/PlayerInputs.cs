using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    public InputSystem_Actions input { get; private set; }

    public Vector2 MoveInput { get; private set; }
    public bool InteractPressed => Keyboard.current.eKey.wasPressedThisFrame;
    public bool LinternaPressed { get; private set; }

    private void Awake()
    {
        input = new InputSystem_Actions();
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

    private void OnMove(InputAction.CallbackContext ctx)
    {
        MoveInput = ctx.ReadValue<Vector2>();
    }

    private void OnLinterna(InputAction.CallbackContext ctx)
    {
        LinternaPressed = true;
    }

    public void ClearLinterna()
    {
        LinternaPressed = false;
    }
}