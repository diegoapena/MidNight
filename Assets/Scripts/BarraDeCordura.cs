using UnityEngine;
using UnityEngine.UI;

public class BarraDeCordura : MonoBehaviour
{
    private Player player;

    [Header("Cordura")]
    public float maxSanity = 100f;
    public float tiempoEntreBajas = 1f;
    private float temporizador = 0f;

    [Header("Interfaz")]
    public Image BarraCordura;
    public Text TextoCordura;

    [Header("Pollutant")]
    public GameObject pollutantPrefab; // Prefab del enemigo
    private bool pollutantActivado = false;

    void Start()
    {
        player = GameObject.Find("Player")?.GetComponent<Player>();

        if (player == null)
        {
            Debug.LogError(" No se encontró el objeto 'Player' o no tiene el script Player.");
            enabled = false;
            return;
        }

        Debug.Log(" Player detectado correctamente");
    }

    void Update()
    {
        if (player == null) return;

        temporizador += Time.deltaTime;


        if (temporizador >= tiempoEntreBajas && player.Sanity > 0)
        {
            player.Sanity -= 2f;
            temporizador = 0f;
        }


        if (player.Sanity <= 0 && !pollutantActivado)
        {
            pollutantActivado = true;
            ActivarPollutant();
        }

        ActualizarInterfaz();
    }

    void ActualizarInterfaz()
    {
        if (BarraCordura != null)
            BarraCordura.fillAmount = player.Sanity / maxSanity;

        if (TextoCordura != null)
            TextoCordura.text = "+ " + player.Sanity.ToString("f0");
    }

    void ActivarPollutant()
    {
        if (pollutantPrefab == null)
        {
            Debug.LogWarning("⚠️ No se asignó el prefab del Pollutant en el Inspector.");
            return;
        }

        Vector3 playerPos = player.transform.position;


        Vector3 spawnPos = playerPos + new Vector3(1.5f, 0, 0);


        GameObject pollutant = Instantiate(pollutantPrefab, spawnPos, Quaternion.identity);
        Debug.Log("☣ Pollutant apareció junto al jugador en " + spawnPos);


        pollutant.GetComponent<PollutantEnemy>().ActivarPollutant();
    }
    public void RestaurarCorduraTotal()
    {
        if (player != null)
        {
            player.Sanity = maxSanity;
            ActualizarInterfaz();
            Debug.Log("🧠 Cordura restaurada al 100%");
        }
    }
}