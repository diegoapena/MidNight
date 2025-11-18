using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemys : MonoBehaviour
{
  /*  [Header("Prefabs de Enemigos")]
    public GameObject shadowPrefab;
    public GameObject noisyPrefab;
    public GameObject shapeshifterPrefab;*/

    [Header("Puntos de Spawn")]
    public Transform[] spawnPoints;

    private List<EnemyTracker> enemyPrefabs;
    private int currentEnemyCount = 0;
    private const int maxEnemies = 10;

    [Header("Barra de Cordura")]
    public BarraDeCordura barraDeCordura; 

    private void Start()
    {
        
    

        
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
        EnemyTracker randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instanciar el enemigo
        EnemyTracker spawnedEnemy = Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity);

        // Incrementar contador de enemigos
        currentEnemyCount++;
        Debug.Log($"Spawned {randomEnemy.name} en {randomSpawnPoint.position}. Total enemigos: {currentEnemyCount}");

        // Activar bajada de cordura al aparecer cualquier enemigo
        if (barraDeCordura != null)
            barraDeCordura.IniciarBajadaCordura();

        
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