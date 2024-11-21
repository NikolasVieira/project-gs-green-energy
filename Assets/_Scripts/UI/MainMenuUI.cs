using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public int levelIndex = 1;
    public void Play() {
        SceneManager.LoadScene(levelIndex);
    }
    public void Config() {
        Debug.Log("Config");
    }
    public void Credits() {
        Debug.Log("Credits");
    }
    public void Quit() {
        Application.Quit();
    }
}
