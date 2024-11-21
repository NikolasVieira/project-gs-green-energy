using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    public GameObject canvas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    void Toggle() {
        canvas.SetActive(!canvas.activeSelf);

        if (canvas.activeSelf)
        {
            Time.timeScale = 0f;
        } else {
            Time.timeScale = 1f;
        }
    }
    public void Continue() { 
        Toggle();
    }

    public void Retry() {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu() {
        SceneManager.LoadScene(0);
    }
}
