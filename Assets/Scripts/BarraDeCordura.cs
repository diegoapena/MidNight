using UnityEngine;
using UnityEngine.UI;
// Este script gestiona la barra de cordura del jugador.
// Reduce o restaura la cordura según las acciones de los enemigos.
// Relación con otros scripts:
// Se relaciona con Player para actualizar su cordura.
// Es afectado por enemigos como ShadowEnemy y PollutantEnemy.
public class BarraDeCordura : MonoBehaviour
{
    public static BarraDeCordura Instance;
    [SerializeField] private float maxCordura = 100f;
    private float corduraActual;
    
    private float tiempoEntreBajas = 1f;
    private float temporizador;
    public Player player;
    public Image BarraCordura;                                                                      
    public Text TextoCordura;
    private bool pollutantSpawned = false;
    private bool corduraBajando = false;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        player.Sanity = maxCordura;
        corduraActual = maxCordura;
        ActualizarInterfaz();
    }

    private void Update()
    {
        PlayerSanity();
        ActualizarInterfaz();

        if (player.Sanity <= 0 && !pollutantSpawned)
        {
            pollutantSpawned = true;

            if (PollutantEnemy.Instance != null)
            {
                PollutantEnemy.Instance.ActivarPollutant();
            }
        }
    }

    private void PlayerSanity()
    {
        if (!corduraBajando) return;

        temporizador += Time.deltaTime;

        if (temporizador >= tiempoEntreBajas)
        {
            if (player.Sanity > 0)
                player.Sanity -= 1f;

            temporizador = 0f;
        }
    }

    private void ActualizarInterfaz()
    {
        if (BarraCordura != null)
            BarraCordura.fillAmount = player.Sanity / maxCordura;

        if (TextoCordura != null)
            TextoCordura.text = player.Sanity.ToString("0");
    }

    public void RestarCordura(float cantidad)
    {
        player.Sanity -= cantidad;
        if (player.Sanity < 0) player.Sanity = 0;

        ActualizarInterfaz();
    }

    public void IniciarBajadaCordura()
    {
        corduraBajando = true;
    }

    public void RestaurarCordura()
    {
        player.Sanity = maxCordura;
        ActualizarInterfaz();
    }
}
