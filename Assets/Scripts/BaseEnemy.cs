using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BaseEnemy : MonoBehaviour
{
    private EnemyDataSO entities;
    private TextMeshProUGUI nombre;
    private TextMeshProUGUI levelOfThreat;
    private TextMeshProUGUI descripcion;

    protected virtual void Start()
    {
        
    }

    // Método para destruir al enemigo
    public void DestroyEnemy()
    {
        Destroy(gameObject); // Destruye el objeto asociado al enemigo
        Debug.Log("Enemigo destruido");
    }
}
