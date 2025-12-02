using UnityEngine;
using UnityEngine.UI;
using TMPro;


// Este script es la clase base para los enemigos.
// Contiene referencias a datos del enemigo (EnemyDataSO) y un método para destruir al enemigo.
// Relación con otros scripts:
// Es heredado por enemigos específicos como ShadowEnemy y PollutantEnemy.
// Puede interactuar con Player y BarraDeCordura para reducir la cordura o causar daño.
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
