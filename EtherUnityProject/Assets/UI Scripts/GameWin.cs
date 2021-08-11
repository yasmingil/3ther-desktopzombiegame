using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
    public static bool gameIsWon = false;
    public GameObject gameWinUI;

    // Update is called once per frame
    void Update()
    {
        if (gameIsWon)
        {
            gameWin();
        }
        else
        {
            gameWinUI.SetActive(false);
        }
    }
    void gameWin()
    {
        gameWinUI.SetActive(true);
        gameIsWon = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}