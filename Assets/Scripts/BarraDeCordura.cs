using UnityEngine;
using UnityEngine.UI;
public class BarraDeCordura : MonoBehaviour
{
    private Player player;
    public float currentsanity = 50;
    [Header("Interfaz")]

    public Image BarraCordura;
    public Text TextoCordura;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        currentsanity = player.Sanity;
    }
    void Update()
    {
        ActualizarInterfaz();
    }
    public void ActualizarInterfaz()
    {
        BarraCordura.fillAmount = player.Sanity / currentsanity;
        TextoCordura.text = "+ " + player.Sanity.ToString("f0");
    }
}
