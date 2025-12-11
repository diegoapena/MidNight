using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryUI : MonoBehaviour
{
    private void Start()
    {
        
        PlayerPrefs.SetInt("Ganaste", 1);
        PlayerPrefs.Save();

        Debug.Log("Progreso guardado: Ganaste = 1");
    }
    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
