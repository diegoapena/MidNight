using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BaseEnemy : MonoBehaviour

{
    [SerializeField] private EnemyDataSO entities;
    [SerializeField] private TextMeshProUGUI nombre;
    //[SerializeField] private TextMeshProUGUI vida;
    [SerializeField] private TextMeshProUGUI levelOfThreat;
    //[SerializeField] private TextMeshProUGUI ataque;
    [SerializeField] private TextMeshProUGUI descripcion;
    //[SerializeField] private Image cara;

    private void Start()
    {
        nombre.text = entities.EnemyName;
        levelOfThreat.text = entities.LevelOfThreat.ToString();
        descripcion.text = entities.Description;
       // cara.sprite = entities.Icon;
    }
}
