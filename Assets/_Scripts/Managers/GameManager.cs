using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;
    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
            return;
            
        if (StatsManager.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame() {
        gameEnded = true;
        Debug.Log("GameOver");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
