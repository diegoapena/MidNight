using UnityEngine;
using System.Collections.Generic;

public class SpawnEnemys : MonoBehaviour
{
    public GameObject shadowPrefab; // Prefab del enemigo Shadow
    public Transform[] spawnPoints; // Puntos de spawn para los enemigos

    private int currentShadowCount = 0; // Contador  de enemigos Shadow activos
    private const int maxShadows = 3; // Aqui es el numro de shadows mximo permitidos
    private List<GameObject> activeShadows = new List<GameObject>(); // Lista de enemigos Shadow activos

    private void Start()
    {
        
        StartSpawning();
    }

    public void StartSpawning()
    {
        
        float initialDelay = Random.Range(1f, 5f); 
        InvokeRepeating(nameof(SpawnShadow), initialDelay, Random.Range(5f, 15f));
    }

    private void SpawnShadow()
    {
        
        if (currentShadowCount >= maxShadows)
        {
            Debug.Log("Límite de Shadows alcanzado. No se generarán más Shadows.");
            return;
        }

        
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("No hay puntos de spawn asignados.");
            return;
        }

        
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        
        GameObject spawnedShadow = Instantiate(shadowPrefab, randomSpawnPoint.position, Quaternion.identity);

        
        currentShadowCount++;
        activeShadows.Add(spawnedShadow);

        Debug.Log($"Spawned Shadow at {randomSpawnPoint.position}. Total Shadows: {currentShadowCount}");

        
        spawnedShadow.AddComponent<ShadowTracker>().Initialize(this);
    }

    public void OnShadowDestroyed(GameObject shadow)
    {
        currentShadowCount--;
        activeShadows.Remove(shadow);
        Debug.Log($"Shadow destruido. Total Shadows: {currentShadowCount}");
    }
}

public class ShadowTracker : MonoBehaviour
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
            spawnEnemys.OnShadowDestroyed(gameObject);
        }
    }
}
