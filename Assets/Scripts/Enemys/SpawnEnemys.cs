using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    [Header("Puntos de Spawn")]
    public Transform[] spawnPoints;

    [Header("Prefabs de Enemigos")]
    public GameObject[] enemyPrefabs;

    private int currentEnemyCount = 0;
    private const int maxEnemies = 10;

    [Header("Barra de Cordura")]
    public BarraDeCordura barraDeCordura; 

    private void Start()
    {
        
        Invoke(nameof(StartSpawning), 60f);
    }

    public void StartSpawning()
    {
        float initialDelay = Random.Range(1f, 5f);
        float repeatRate = Random.Range(5f, 15f);

        InvokeRepeating(nameof(SpawnEnemy), initialDelay, repeatRate);
    }

    private void SpawnEnemy()
    {
        if (currentEnemyCount >= maxEnemies) return;

        // Elegir enemigo aleatorio
        GameObject randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Elegir punto aleatorio
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instanciar enemigo
        GameObject spawnedEnemy = Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity);

        currentEnemyCount++;
        Debug.Log($"Spawned: {randomEnemy.name} en {randomSpawnPoint.position}. Total: {currentEnemyCount}");

        // Activar bajada de cordura
        barraDeCordura?.IniciarBajadaCordura();

        // Añadir tracker al enemigo para detectar cuando muere
        spawnedEnemy.AddComponent<EnemyTracker>().Initialize(this);
    }

    public void OnEnemyDestroyed()
    {
        currentEnemyCount--;
        Debug.Log($"Enemigo destruido. Total enemigos: {currentEnemyCount}");
    }
}