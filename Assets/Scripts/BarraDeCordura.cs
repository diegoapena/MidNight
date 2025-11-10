using UnityEngine;
using UnityEngine.UI;

public class BarraDeCordura : MonoBehaviour
{
    private Player player;
    private int corduraActual = 100; // Valor inicial de la cordura

    [Header("Cordura")]
    public float maxSanity = 100f;
    public float tiempoEntreBajas = 1f;
    private float temporizador = 0f;
    private bool corduraBajando = false; 

    [Header("Interfaz")]
    public Image BarraCordura;
    public Text TextoCordura;

    void Start()
    {
        player = GameObject.Find("Player")?.GetComponent<Player>();
        if (player == null)
        {
            Debug.LogError("No se encontró el Player");
            enabled = false;
            return;
        }

        ActualizarInterfaz();
    }

    void Update()
    {
        if (player == null) return;

        
        if (corduraBajando && temporizador >= tiempoEntreBajas)
        {
            if (player.Sanity > 0)
                player.Sanity -= 2f;

            temporizador = 0f;
        }

        temporizador += Time.deltaTime;

        ActualizarInterfaz();
    }

    void ActualizarInterfaz()
    {
        if (BarraCordura != null)
            BarraCordura.fillAmount = player.Sanity / maxSanity;

        if (TextoCordura != null)
            TextoCordura.text = player.Sanity.ToString("f0");
    }

    public void ReducirCordura(int cantidad)
    {
        corduraActual -= cantidad;
        corduraActual = Mathf.Clamp(corduraActual, 0, 100); // Asegurarse de que la cordura no sea menor a 0
        Debug.Log($"Cordura reducida en {cantidad}. Cordura actual: {corduraActual}");

        // Aquí puedes agregar lógica para actualizar la barra de cordura en la interfaz
    }

    public void IniciarBajadaCordura()
    {
        corduraBajando = true;
        Debug.Log("Bajada de cordura activada");
    }
}