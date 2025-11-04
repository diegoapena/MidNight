using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.VFX;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private RoomManager roomManager; // D: Referencia al RoomManager
    [SerializeField] private GameObject player; // D: Referencia al Player
    [SerializeField] private SpawnEnemys spawnEnemys; // D: Referencia al SpawnEnemys

    private float timeElapsed;
    private int minutes, seconds, cents;
    private bool spawnStarted = false; // D: Bandera para iniciar el spawn

    private void Update()
    {
        Timer();
        timeElapsed += Time.deltaTime;

        // Iniciar el spawn de enemigos a partir del segundo 60
        if (timeElapsed >= 60f && !spawnStarted)
        {
            spawnStarted = true;
            spawnEnemys.StartSpawning(); // Llamar al método para iniciar el spawn
        }
    }

    public void Timer()
    {
        timeElapsed += Time.deltaTime;
        minutes = (int)(timeElapsed / 60f);
        seconds = (int)(timeElapsed - minutes * 60f);
        cents = (int)((timeElapsed - (int)timeElapsed) * 100f);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, cents);
    }
}