using UnityEngine;

// Este ScriptableObject almacena datos configurables de los enemigos, como nombre, salud, daño, nivel de amenaza, etc.
// Relación con otros scripts:
// Es utilizado por BaseEnemy y sus derivados para definir las características de cada enemigo.
[CreateAssetMenu(fileName = "EnemyDataSO", menuName = "MidNight/Scripts/EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
{
   
    public string EnemyName;
    public ulong ID;
    public int Health;
    public int Damage;
    public float LevelOfThreat;
    public Sprite Icon;

    [TextArea(2, 2)] 
    public string Description;

}
