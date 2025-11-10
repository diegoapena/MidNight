using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    private string enemyName;
    private int health;
    private int damage;
    private float speed;

    private BarraDeCordura barraDeCordura; // Referencia al script de la barra de cordura

    public void Initialize(EnemyDataSO data)
    {
        enemyName = data.EnemyName;
        health = data.Health;
        damage = data.Damage;
        speed = data.Speed;

        Debug.Log($"Iniciado enemigo: {enemyName} con {health} de salud, {damage} de daño y {speed} de velocidad.");

        // Buscar la barra de cordura en la escena
        barraDeCordura = FindObjectOfType<BarraDeCordura>();

        // Reducir la cordura del jugador
        if (barraDeCordura != null)
        {
            barraDeCordura.ReducirCordura(1); // Reducir la cordura en 10 puntos (puedes ajustar este valor)
        }
        else
        {
            Debug.LogError("No se encontró el script BarraDeCordura en la escena.");
        }
    }
}
