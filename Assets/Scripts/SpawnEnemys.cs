using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
    [Header("Prefabs de Enemigos")]
    public GameObject shadowPrefab;
    public GameObject noisyPrefab;
    public GameObject shapeshifterPrefab;

    [Header("Puntos de Spawn")]
    public Transform[] spawnPoints;

    private GameObject[] enemyPrefabs;
    private int currentEnemyCount = 0;
    private const int maxEnemies = 10;

    [Header("Barra de Cordura")]
    public BarraDeCordura barraDeCordura; 

    private void Start()
    {
        
        enemyPrefabs = new GameObject[] { shadowPrefab, noisyPrefab, shapeshifterPrefab };

        
    }

    
    public void StartSpawning()
    {
        float initialDelay = Random.Range(1f, 5f);
        InvokeRepeating(nameof(SpawnEnemy), initialDelay, Random.Range(5f, 15f));
        
    }

    private void SpawnEnemy()
    {
        // Verificar límite de enemigos
        if (currentEnemyCount >= maxEnemies) return;

        // Elegir prefab y punto de spawn aleatorio
        GameObject randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instanciar el enemigo
        GameObject spawnedEnemy = Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity);

        // Incrementar contador de enemigos
        currentEnemyCount++;
        Debug.Log($"Spawned {randomEnemy.name} en {randomSpawnPoint.position}. Total enemigos: {currentEnemyCount}");

        // Activar bajada de cordura al aparecer cualquier enemigo
        if (barraDeCordura != null)
            barraDeCordura.IniciarBajadaCordura();

        // Añadir EnemyTracker para disminuir el contador al destruirse
        spawnedEnemy.AddComponent<EnemyTracker>().Initialize(this);
    }

    
    public void OnEnemyDestroyed()
    {
        currentEnemyCount--;
        Debug.Log($"Enemigo destruido. Total enemigos: {currentEnemyCount}");
    }
}


public class EnemyTracker : MonoBehaviour
{
    private SpawnEnemys spawnEnemys;

    public void Initialize(SpawnEnemys spawnEnemys)
    {
        this.spawnEnemys = spawnEnemys;
    }

    private void OnDestroy()
    {
        if (spawnEnemys != null)
        {
            spawnEnemys.OnEnemyDestroyed();
        }
    }
}