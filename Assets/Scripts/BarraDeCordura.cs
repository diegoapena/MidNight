using UnityEngine;
using UnityEngine.UI;

public class BarraDeCordura : MonoBehaviour
{
    public static BarraDeCordura Instance;

    [Header("Cordura")]
    public float maxSanity = 100f;
    public float tiempoEntreBajas = 1f;
    private float temporizador;
    private bool corduraBajando;

    [Header("Referencias")]
    public Player player;
    public Image BarraCordura;
    public Text TextoCordura;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        player.Sanity = maxSanity;
        ActualizarInterfaz();
    }

    private void Update()
    {
        PlayerSanity();
        ActualizarInterfaz();
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
            BarraCordura.fillAmount = player.Sanity / maxSanity;

        if (TextoCordura != null)
            TextoCordura.text = player.Sanity.ToString("0");
    }

    public void RestarCordura(float cantidad)
    {
        player.Sanity -= cantidad;

        if (player.Sanity < 0)
            player.Sanity = 0;

        ActualizarInterfaz();
    }

    public void IniciarBajadaCordura()
    {
        corduraBajando = true;
    }
}