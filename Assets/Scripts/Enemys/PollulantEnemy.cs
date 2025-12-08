using UnityEngine;
using UnityEngine.SceneManagement;
// Este script controla el comportamiento del enemigo "Pollutant".
// Persigue al jugador y lo elimina al alcanzarlo.

// Se relaciona con Player para perseguirlo y atacarlo.
// Es activado por BarraDeCordura cuando la cordura del jugador llega a 0.
public class PollutantEnemy : MonoBehaviour
{


    public static PollutantEnemy Instance;

    
    public float delayAparicion = 0.5f;

    
    public float velocidad = 2f;

    private Transform jugador;
    private bool persiguiendo = false;

    private void Awake()
    {
        Instance = this;
    }

    public void ActivarPollutant()
    {
        
        jugador = Player.Instance != null ? Player.Instance.transform : null;

        if (jugador == null)
        {
            Debug.LogError(" Player.Instance es NULL — No se encontró al jugador.");
            return;
        }

        
        transform.position = jugador.position + new Vector3(1.5f, 0, 0);

        gameObject.SetActive(true);

        
        Invoke(nameof(ComenzarPersecucion), delayAparicion);
    }

    private void ComenzarPersecucion()
    {
        persiguiendo = true;
        Debug.Log(" Pollutant te perseguira hasta la MUERTE");
    }

    private void Update()
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log(" Pollutant mató al jugador");
             Destroy(collision.gameObject);

            SceneManager.LoadScene("GameOver");
        }
    }
}
