using UnityEngine;
using UnityEngine.SceneManagement;
public class WinUI : MonoBehaviour
{
    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu() {
        SceneManager.LoadScene(0);
    }
}
