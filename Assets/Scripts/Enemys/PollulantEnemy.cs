using UnityEngine;
using UnityEngine.SceneManagement;

public class PollutantEnemy : BaseEntity
{
    public static PollutantEnemy Instance { get; private set; }

    [Header("Aparición")]
    public float delayAparicion = 0.5f;
    public string escenaFinal = "FinalSinEscape";

    [Header("Movimiento")]
    public float velocidad = 2f;

    private Transform jugador;
    private bool persiguiendo = false;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false); // Inicia oculto
    }

    // Llamado cuando la cordura llega a 0
    public void ActivarPollutant()
    {
        jugador = Player.Instance.transform;

        // Aparece al lado del jugador
        transform.position = jugador.position + new Vector3(1.5f, 0, 0);

        gameObject.SetActive(true);

        // Inicia su aparición después del delay
        Invoke(nameof(Aparecer), delayAparicion);
    }

    void Aparecer()
    {
        persiguiendo = true;
        Debug.Log("Pollutant comenzó a perseguir al jugador.");
        BloquearPuertas();
    }

    void Update()
    {
        PollutantRun();
    }

    void PollutantRun()
    {
        if (persiguiendo && jugador != null)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                jugador.position,
                velocidad * Time.deltaTime
            );
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Pollutant atrapó al jugador. Fin del juego.");
            SceneManager.LoadScene(escenaFinal);
        }
    }

    void BloquearPuertas()
    {
        BaseInteractable[] puertas = Object.FindObjectsByType<BaseInteractable>(FindObjectsSortMode.None);
        foreach (var puerta in puertas)
            puerta.enabled = false;

        Debug.Log("Puertas bloqueadas por Pollutant.");
    }
}