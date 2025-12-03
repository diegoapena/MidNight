using UnityEngine;
using UnityEngine.InputSystem;
// Este script gestiona las entradas del jugador, como movimiento, interacción y uso de la linterna.
// Relación con otros scripts:
// Es utilizado por Player para manejar las acciones del jugador.
public class PlayerInputs : MonoBehaviour
{
    public InputSystem_Actions input;

    public Vector2 MoveInput;
    public bool InteractPressed;
    public bool LinternaPressed;

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