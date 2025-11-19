using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    private SpawnEnemys spawnScript;

    public void Initialize(SpawnEnemys spawn)
    {
        spawnScript = spawn;
    }

    private void OnDestroy()
    {
        if (spawnScript != null)
            spawnScript.OnEnemyDestroyed();
    }
}