using UnityEngine;
using TMPro;
using System.Threading;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private RoomManager roomManager; // tenemos la referencia al RoomManager
    [SerializeField] private GameObject player; // tenemos la referencia al Player

    private float timeElapsed;
    private int minutes, seconds, cents;

    private void Update()
    {
        Timer();
       
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