using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver = false;
    public GameObject gameOverUI;

    void Start() {
        GameIsOver = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;
            
        if (StatsManager.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame() {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
