using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryUI : MonoBehaviour
{
    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
