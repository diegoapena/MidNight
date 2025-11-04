using UnityEngine;

[CreateAssetMenu(fileName = "EnemyDataSO", menuName = "MidNight/Scripts/EnemyDataSO")]
public class EnemyDataSO : ScriptableObject
{
    public string EnemyName;
    public ulong ID;
    public int Health;
    public int Damage;
    public float Speed;
    public Sprite Icon;
}
