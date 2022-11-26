using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Generacion de enemigos")]
    [SerializeField] Generacion_Enemigos generadorEnemigos; //Referencia a Script de generación
    [SerializeField] bool estaGenerando;    //No se si sea necesario implementar esto, revisar
    public int enemigosEnJuego;   //Incrementar al spawnear un enemigo
    public int numeroDeRonda; //Numero de ronda


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (enemigosEnJuego == 0){
            generadorEnemigos.IniciarGeneracionEnemigos();
        }
    }
}
