using UnityEngine;
using UnityEngine.SceneManagement;

public class PollutantEnemy : BaseEntity
{
    [Header("Aparición")]
    public float delayAparicion = 0.5f;
    public string escenaFinal = "FinalSinEscape";

    [Header("Movimiento")]
    public float velocidad = 2f;

    private Transform jugador;
    private bool persiguiendo = false;

    public void ActivarPollutant()
    {
        Invoke(nameof(Aparecer), delayAparicion);
    }

    void Aparecer()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        persiguiendo = true;
        Debug.Log("☣ Pollutant comenzó a perseguir al jugador.");
        BloquearPuertas();
    }

    void Update()
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
            Debug.Log("☣ Pollutant atrapó al jugador. Fin del juego.");
            SceneManager.LoadScene(escenaFinal);
        }
    }

    void BloquearPuertas()
    {
        BaseInteractable[] puertas = Object.FindObjectsByType<BaseInteractable>(FindObjectsSortMode.None);
        foreach (var puerta in puertas)
            puerta.enabled = false;

        Debug.Log("🚪 Todas las puertas han sido bloqueadas por Pollutant.");
    }
}