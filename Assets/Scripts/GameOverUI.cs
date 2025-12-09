using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
