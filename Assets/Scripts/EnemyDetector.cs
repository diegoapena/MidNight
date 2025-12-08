using UnityEngine;
using UnityEngine.UI;

public class EnemyPointer : MonoBehaviour
{
    public Transform player;           
    public RectTransform arrowUI;     
    public float distanceFromPlayer = 150f; 

    void Update()
    {
        // Buscar enemigo más cercano
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            arrowUI.gameObject.SetActive(false);
            return;
        }

        arrowUI.gameObject.SetActive(true);

        Transform closestEnemy = enemies[0].transform;
        float closestDist = Vector3.Distance(player.position, closestEnemy.position);

        foreach (GameObject e in enemies)
        {
            float dist = Vector3.Distance(player.position, e.transform.position);
            if (dist < closestDist)
            {
                closestDist = dist;
                closestEnemy = e.transform;
            }
        }

        // Direccion hacia el enemigo
        Vector3 dir = (closestEnemy.position - player.position).normalized;

        //  Rotar la flecha hacia el enemigo
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        arrowUI.rotation = Quaternion.Euler(0, 0, angle - 90f);

        
        arrowUI.anchoredPosition = dir * distanceFromPlayer;
    }
}