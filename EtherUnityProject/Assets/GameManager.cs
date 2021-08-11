using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameOver = false;

    public void GameOver()
    {
        if(!gameOver)
        {
            gameOver = true;
            Debug.Log("Death Animation");
            Invoke("Restart", 1f);
        }

    }
    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
