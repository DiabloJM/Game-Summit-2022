using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayLoop : MonoBehaviour
{
    public GameObject gameOverPanel; //Text
    public GameObject gameWinPanel;


    void Start()
    {
        gameOverPanel.gameObject.SetActive(false);
        gameWinPanel.gameObject.SetActive(false);

    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.gameObject.SetActive(true);
        Debug.Log("Hola");
    }

    public void ShowWinScreen()
    {
        Time.timeScale = 0f;
        gameWinPanel.gameObject.SetActive(true);
        Debug.Log("Win Scren");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Has cerrado el juego");
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
