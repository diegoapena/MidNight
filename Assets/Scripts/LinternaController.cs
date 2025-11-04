using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LinternaController : MonoBehaviour
{
    public Light2D flashlight;
    public float rotationSpeed = 8f;
    private bool isOn = false;
    private Vector2 lastMoveDir = Vector2.down;

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveDir = new Vector2(moveX, moveY);

        if (moveDir != Vector2.zero)
            lastMoveDir = moveDir.normalized;

        float angle = Mathf.Atan2(lastMoveDir.y, lastMoveDir.x) * Mathf.Rad2Deg;

        
        flashlight.transform.rotation = Quaternion.Lerp(
            flashlight.transform.rotation,
            Quaternion.Euler(0, 0, angle - 90f),
            Time.deltaTime * rotationSpeed
        );

        if (Input.GetKeyDown(KeyCode.F))
        {
            isOn = !isOn;
            flashlight.enabled = isOn;
        }
    }
}