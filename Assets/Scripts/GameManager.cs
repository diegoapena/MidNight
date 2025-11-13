using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
public class GameManager : MonoBehaviour
{ 
[SerializeField] private TMP_Text timerText;
[SerializeField] private RoomManager roomManager;
[SerializeField] private GameObject player;
[SerializeField] private SpawnEnemys spawnEnemys;

private float timeElapsed;
private int minutes, seconds, cents;
private bool spawnStarted = false; // Bandera para iniciar el spawn

private void Update()
{
    // Actualizar el tiempo
    timeElapsed += Time.deltaTime;
    Timer();

    // Iniciar el spawn de enemigos cuando llegue al minuto 1
    if (!spawnStarted && timeElapsed >= 60f)
    {
        spawnStarted = true;
        spawnEnemys.StartSpawning();
        Debug.Log(" Spawn de enemigos iniciado al minuto 1");
    }
}

private void Timer()
{
    minutes = (int)(timeElapsed / 60f);
    seconds = (int)(timeElapsed % 60f);
    cents = (int)((timeElapsed - (int)timeElapsed) * 100f);

    if (timerText != null)
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, cents);
}
}