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

    public void StartSpawning()
    {
        float initialDelay = Random.Range(1f, 5f);
        InvokeRepeating(nameof(SpawnEnemy), initialDelay, Random.Range(5f, 15f));
    }

    private void SpawnEnemy()
    {
        if (currentEnemyCount >= maxEnemies) return;

        // Elegir enemigo aleatorio
        GameObject randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Elegir punto aleatorio
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instanciar
        GameObject spawnedEnemy = Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity);

        currentEnemyCount++;
        Debug.Log($"Spawned {randomEnemy.name} en {randomSpawnPoint.position}. Total enemigos: {currentEnemyCount}");

        // Activar bajada de cordura
        if (barraDeCordura != null)
            barraDeCordura.IniciarBajadaCordura();

        // Añadir tracker
        spawnedEnemy.AddComponent<EnemyTracker>().Initialize(this);
    }

    public void OnEnemyDestroyed()
    {
        currentEnemyCount--;
        Debug.Log($"Enemigo destruido. Total enemigos: {currentEnemyCount}");
    }
    private void Start()
    {
        StartSpawning();
    }
}