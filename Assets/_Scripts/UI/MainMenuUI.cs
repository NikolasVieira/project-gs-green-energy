using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public int levelIndex = 1;
    public GameObject canvasCredits;
    public bool isCreditsActive = false;
    public void Play() {
        SceneManager.LoadScene(levelIndex);
    }
    public void Config() {
        Debug.Log("Config");
    }
    public void Credits() {
        canvasCredits.SetActive(!isCreditsActive);
        isCreditsActive = !isCreditsActive;
    }
    public void Quit() {
        Application.Quit();
    }
}
