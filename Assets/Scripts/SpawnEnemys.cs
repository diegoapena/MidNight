using UnityEngine;
using System.Collections.Generic;

public class SpawnEnemys : MonoBehaviour
{
    public GameObject shadowPrefab; // Prefab del enemigo Shadow
    public GameObject noisyPrefab; // Prefab del enemigo Noisy
    public GameObject shapeshifterPrefab; // Prefab del enemigo Shapeshifter
    public GameObject pollutantPrefab; // Prefab del enemigo Pollutant

    public Transform[] spawnPoints; // Puntos de spawn para los enemigos

    private GameObject[] enemyPrefabs; // Array para almacenar los prefabs de enemigos
    private int currentEnemyCount = 0; // Contador de enemigos activos
    private const int maxEnemies = 10; // Máximo número de enemigos permitidos

    private void Start()
    {
        // Inicializar el array de prefabs
        enemyPrefabs = new GameObject[] { shadowPrefab, noisyPrefab, shapeshifterPrefab, pollutantPrefab };
        StartSpawning();
    }

    public void StartSpawning()
    {
        // Iniciar el spawn repetitivo con un intervalo aleatorio
        float initialDelay = Random.Range(1f, 5f); // Tiempo inicial aleatorio
        InvokeRepeating(nameof(SpawnEnemy), initialDelay, Random.Range(5f, 15f));
    }

    private void SpawnEnemy()
    {
        // Verificar si se alcanzó el límite de enemigos
        if (currentEnemyCount >= maxEnemies)
        {
            Debug.Log("Límite de enemigos alcanzado. No se generarán más enemigos.");
            return;
        }

        // Elegir un prefab aleatorio
        GameObject randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Elegir un punto de spawn aleatorio
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instanciar el enemigo
        GameObject spawnedEnemy = Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity);

        // Incrementar el contador de enemigos
        currentEnemyCount++;

        Debug.Log($"Spawned {randomEnemy.name} at {randomSpawnPoint.position}. Total enemigos: {currentEnemyCount}");

        // Suscribirse al evento de destrucción del enemigo
        spawnedEnemy.AddComponent<EnemyTracker>().Initialize(this);
    }

    // Método para reducir el contador de enemigos cuando uno es destruido
    public void OnEnemyDestroyed()
    {
        currentEnemyCount--;
        Debug.Log($"Enemigo destruido. Total enemigos: {currentEnemyCount}");
    }
}

// Clase auxiliar para rastrear la destrucción de enemigos

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
