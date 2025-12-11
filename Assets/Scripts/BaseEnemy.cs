using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Este script es la clase base para los enemigos.
// Contiene referencias a datos del enemigo (EnemyDataSO) y un método para destruir al enemigo.
// Relación con otros scripts:
// Es heredado por enemigos específicos como ShadowEnemy y PollutantEnemy.
// Puede interactuar con Player y BarraDeCordura para reducir la cordura o causar daño.
public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private List<EnemyDataSO> enemyDataList;
    [SerializeField] private TextMeshProUGUI nombre;
    [SerializeField] private TextMeshProUGUI levelOfThreat;
    [SerializeField] private TextMeshProUGUI descripcion;
    [SerializeField] private Image cara;

    private int currentEnemyIndex = 0;

    private void Start()
    {
        if (enemyDataList != null && enemyDataList.Count > 0)
        {
            UpdateEnemyData(enemyDataList[currentEnemyIndex]);
        }
    }


    private void UpdateEnemyData(EnemyDataSO enemyData)
    {
        nombre.text = enemyData.EnemyName;
        levelOfThreat.text = enemyData.LevelOfThreat.ToString();
        descripcion.text = enemyData.Description;
        cara.sprite = enemyData.Icon;
    }


    public void NextEnemy()
    {
        if (enemyDataList == null || enemyDataList.Count == 0) return;

        currentEnemyIndex = (currentEnemyIndex + 1) % enemyDataList.Count;
        UpdateEnemyData(enemyDataList[currentEnemyIndex]);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }


    public virtual void DestroyEnemy()
    {
        Destroy(gameObject);
        Debug.Log("Enemigo destruido");
    }
}
