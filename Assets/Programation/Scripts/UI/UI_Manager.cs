using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public static bool GameIsPaused = false;

    [Header("Gameplay")]
    public GameObject Player;
    public GameObject pauseMenuUI;
    public GameObject InGameUI;
    public GameObject PauseButtonUI;

    [Header("TutorialSheets")]
    public GameObject Tutorial_UI;
    public GameObject TutorialPrt1;
    public GameObject TutorialPrt2;
    public GameObject TutorialPrt3;




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))

        {
            Debug.Log("the game is paused");
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        InGameUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; ;
        GameIsPaused = false;
    }

    public void Pause()
    {
        InGameUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Quitting Game...");
        SceneManager.LoadScene("Main");
    }

    public void TutorialStart()
    {
        pauseMenuUI.SetActive(false);
        Tutorial_UI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void TutorialFinish()
    {
        Tutorial_UI.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Part1Next()
    {
        TutorialPrt1.SetActive(false);
        TutorialPrt2.SetActive(true);
    }

    public void Part2Next()
    {
        TutorialPrt2.SetActive(false);
        TutorialPrt3.SetActive(true);
    }

    public void Part2Back()
    {
        TutorialPrt1.SetActive(true);
        TutorialPrt2.SetActive(false);
    }

    public void Part3Back()
    {
        TutorialPrt2.SetActive(true);
        TutorialPrt3.SetActive(false);
    }

    public void PlayButtonSound()
    {
        //Aqui on que se reproduzca un sonido
    }

    public void UpdatePlayerHealth()
    {
        //Cada que el jugador sea da�ado, llamar esta funcion para actualizar su barra de vida
    }

    public void UpdateEnemyHealth(/*Aqui podrias meter algo para referenciar al enemigo, como un Gameobject y ingresas 'this.gameObject*/)
    {
        //Cada que el enemigo sea da�ado, llamar esta funcion para actualizar su barra de vida
        //Necesita referencias individuales, suerte
    }

    public void EndGame()
    {
        //Time scale set to 0
        //Display GameOver Screen
    }

    public void RestartScene()
    {
        //Restart current scene by name
    }
}
