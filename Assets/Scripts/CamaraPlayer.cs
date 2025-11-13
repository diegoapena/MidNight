using UnityEngine;

public class CamaraPlayer : MonoBehaviour
{
    public GameObject Player;
    public float Speed = 2f;

    void Update()
    {
        CamaraPlayerLerp();
    }

    private void CamaraPlayerLerp()
    {
        float x = Player.transform.position.x;
        float y = Player.transform.position.y;
        Vector3 targetPosition = new Vector3(x, y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Speed * Time.deltaTime);
    }
}
