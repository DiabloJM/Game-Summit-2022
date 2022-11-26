using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generacion_Enemigos : MonoBehaviour
{
    //Variables publicas
    [Header("Rondas")]
    public int ronda = 1; //Numero de ronda en la que estamos actualmente

    [Header("Referencias")]
    public Transform spawn; //Lugar donde los enemigos se van a generar

    [Header("Enemigos")]
    public GameObject[] prefabsEenemigos; //Arreglo de prefabs de los enemigos

    //Variables privadas
    private int enemigos = 3; //Numero de enemigos que se generaran en la ronda actual
    private int rondaSegundoEnemigo = 3; //Ronda en la que empieza a salir el segundo enemigo
    private int rondaTercerEnemigo = 7; //Ronda en la que empieza a salir el tercer enemigo

    private void Start()
    {
        //Llamamos a la corutina para generar enemigos
        StartCoroutine(IniciarGeneracionEnemigos());
    }

    //Corutina para generar a los enemigos necesarios por ronda
    IEnumerator IniciarGeneracionEnemigos()
    {
        //Tiempo de espera al inicio de ronda
        yield return 3.0f;

        //Generar enemigos
        for(int i = 0; i < enemigos; i++)
        {
            if(ronda >= rondaTercerEnemigo)
            {
                //Indice random para saber cual de los 3 enemigos del arreglo se va a generar
                int random = Random.Range(0, 3);
                Instantiate(prefabsEenemigos[random], spawn);
            }
            else if(ronda >= rondaSegundoEnemigo)
            {
                //Indice random para saber cual de los primeros 2 enemigos del arreglo se va a generar
                int random = Random.Range(0, 2);
                Instantiate(prefabsEenemigos[random], spawn);
            }
            else
            {
                //Generar al primer enemigo del arreglo
                Instantiate(prefabsEenemigos[0], spawn);
            }

            //Tiempo de espera entre la generacion de un enemigo y otro
            yield return 1.5f;
        }

        //Se suma la cantidad de enemigos que se generar�n la siguiente ronda y pasamos de ronda
        enemigos += 2;
        ronda++;

        
        //Hacemos que la corutina se llame as� misma para que sea recursiva mientras la ronda sea menor a 11
        if(ronda < 11)
        {
            StartCoroutine(IniciarGeneracionEnemigos());
        }
    }
}
