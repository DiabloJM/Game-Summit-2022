using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generacion_Enemigos : MonoBehaviour
{
    //Variables publicas
    [Header("Referencias")]
    
    public Transform spawn; //Lugar donde los enemigos se van a generar
    public GameManager manager; //Referencia al GameManager

    [Header("Enemigos")]
    public GameObject[] prefabsEnemigos; //Arreglo de prefabs de los enemigos

    //Variables privadas
    private int enemigos = 3; //Numero de enemigos que se generaran en la ronda actual
    private int rondaSegundoEnemigo = 3; //Ronda en la que empieza a salir el segundo enemigo
    private int rondaTercerEnemigo = 7; //Ronda en la que empieza a salir el tercer enemigo

    //Start
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Testing singleton de mecanica, funcional en primer ciclo
        //Debug.Log("Coroutine called");
    }

    public void CallRoundStartCoRoutine()
    {
        StartCoroutine(IniciarGeneracionEnemigos());
    }

    //Corutina para generar a los enemigos necesarios por ronda
    public IEnumerator IniciarGeneracionEnemigos()
    {
        Debug.Log("Coroutine Start");

        //Tiempo de espera al inicio de ronda
        yield return new WaitForSeconds(2.0f);

        //Generar enemigos
        for(int i = 0; i < enemigos; i++)
        {
            if(manager.numeroDeRonda >= rondaTercerEnemigo)
            {
                //Indice random para saber cual de los 3 enemigos del arreglo se va a generar
                int random = Random.Range(0, 3);
                Instantiate(prefabsEnemigos[random], spawn);
            }
            else if(manager.numeroDeRonda >= rondaSegundoEnemigo)
            {
                //Indice random para saber cual de los primeros 2 enemigos del arreglo se va a generar
                int random = Random.Range(0, 2);
                Instantiate(prefabsEnemigos[random], spawn);
            }
            else
            {
                //Generar al primer enemigo del arreglo
                Instantiate(prefabsEnemigos[0], spawn);
            }

            //Tiempo de espera entre la generacion de un enemigo y otro
            yield return new WaitForSeconds(1.0f);
        }

        //Se suma la cantidad de enemigos que se generar�n la siguiente ronda y pasamos de ronda
        enemigos += 2;
    }
}
