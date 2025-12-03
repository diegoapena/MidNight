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
    [SerializeField ]private EnemyDataSO entities;
    [SerializeField]private TextMeshProUGUI nombre;
    [SerializeField] private TextMeshProUGUI levelOfThreat;
    [SerializeField] private TextMeshProUGUI descripcion;
    [SerializeField] private Image cara;


    private void Start()
    {
        nombre.text = entities.EnemyName;
        levelOfThreat.text = entities.LevelOfThreat.ToString();
        descripcion.text = entities.Description;
        cara.sprite = entities.Icon;
    }
    
    // Método para destruir al enemigo
    public void DestroyEnemy()
    {
        Destroy(gameObject); // Destruye el objeto asociado al enemigo
        Debug.Log("Enemigo destruido");
    }
}   
