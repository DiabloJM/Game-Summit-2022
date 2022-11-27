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
    public GameObject GameOverUI;

    [Header("TutorialSheets")]
    public GameObject Tutorial_UI;
    public GameObject TutorialPrt1;
    public GameObject TutorialPrt2;
    public GameObject TutorialPrt3;

    [Header("MenuUI")]
    public Animator TitleImage;
    public AudioSource AudioInicio;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

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

    public void DeadScreen()
    {
        InGameUI.SetActive(false);
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
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

    public void LoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void StartingGame()
    {
        StartCoroutine(Arranque());
    }

    public void ElegirTorreta(StoreManager botonDeTorreta)
    {
        if (ScoreManager.scoreValue < botonDeTorreta.precio)
            return;
        Texture2D cursor = botonDeTorreta.cursor;
        Vector2 posicion = botonDeTorreta.posicion;
        Cursor.SetCursor(cursor, posicion, CursorMode.Auto);
        BuildManager.instance.estoyConstruyendo = true;
        BuildManager.precioActual = botonDeTorreta.precio;
        BuildManager.instance.contadorDeTorretas = botonDeTorreta.torretaAConstruir;
    }

    IEnumerator Arranque()
    {
        TitleImage.SetBool("startGame", true);

        AudioInicio.Play();

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("ColocarTorres");
    }
}
