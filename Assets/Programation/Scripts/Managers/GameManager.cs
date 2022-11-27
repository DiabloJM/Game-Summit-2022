using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Generacion de enemigos")]
    [SerializeField] Generacion_Enemigos generadorEnemigos; //Referencia a Script de generación
    public int enemigosEnJuego;   //Incrementar al spawnear un enemigo
    public int numeroDeRonda; //Numero de ronda

    [Header("Vida Base")]
    public int vidaBase = 10;
    public float vidaMax = 10;
    public Image vidaBar;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        InvokeRepeating("CheckForEnemies",0.0f, 3.0f);

        Application.targetFrameRate = 60;
    }

    void CheckForEnemies()
    {
        if (enemigosEnJuego == 0 && numeroDeRonda <= 10)
        {
            LlamarInicioDeGeneracion();
            numeroDeRonda++;
            ComportamientoBase.MoverPosicion();
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (numeroDeRonda == 11 && enemigosEnJuego == 0)
        {
            //Win Condition
            Debug.Log("Ganaste");
        }

        if (vidaBase <= 0)
        {
            SceneManager.LoadScene("GameOver");
            //Lose Condition
            Debug.Log("Mamaste");
        }

        Desgaste();
    }

    public void LlamarInicioDeGeneracion()
    {
        generadorEnemigos.CallRoundStartCoRoutine();
    }

    public void Desgaste()
    {
        vidaBar.fillAmount = vidaBase / vidaMax;
    }
}
