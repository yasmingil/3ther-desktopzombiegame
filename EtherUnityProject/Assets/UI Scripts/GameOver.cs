using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public bool GameIsOver = false;
    public GameObject gameOverUI;

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            gameOver();
        } else
        {
            gameOverUI.SetActive(false);
        }
    }
    void gameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}