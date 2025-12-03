using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    [Header("Puntos de Spawn por Tipo")]
    public Transform[] shapeshifterSpawnPoints;
    public Transform[] shadowSpawnPoints;
    public Transform[] noisySpawnPoints;
    public Transform[] ShapeshifterBedSpawnPoint;

    [Header("Prefabs de Enemigos")]
    public GameObject shapeshifterEnemyPrefab;
    public GameObject shadowPrefab;
    public GameObject noisyPrefab;
    public GameObject ShapeshifterBed;

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

        InvokeRepeating(nameof(Spawnshapeshifter), initialDelay, repeatRate);
        InvokeRepeating(nameof(SpawnShadow), initialDelay + 2f, repeatRate + 3f);
        InvokeRepeating(nameof(SpawnNoisy), initialDelay + 4f, repeatRate + 5f);
    }

    private void Spawnshapeshifter()
    {
        SpawnEnemy(shapeshifterEnemyPrefab, shapeshifterSpawnPoints);
        SpawnEnemy(ShapeshifterBed, ShapeshifterBedSpawnPoint);
    }

    private void SpawnShadow()
    {
        SpawnEnemy(shadowPrefab, shadowSpawnPoints);
    }

    private void SpawnNoisy()
    {
        SpawnEnemy(noisyPrefab, noisySpawnPoints);
    }

    private void SpawnEnemy(GameObject enemyPrefab, Transform[] spawnPoints)
    {
        if (currentEnemyCount >= maxEnemies) return;

        // Elegir punto aleatorio del tipo correspondiente
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instanciar enemigo
        GameObject spawnedEnemy = Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);

        currentEnemyCount++;
        Debug.Log($"Spawned: {enemyPrefab.name} en {randomSpawnPoint.position}. Total: {currentEnemyCount}");

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