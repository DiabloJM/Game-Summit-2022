using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Torreta : MonoBehaviour
{
    
    private Transform objetivo;

    [Header("Stats")]
    [SerializeField] TorreStatsSo stats;
    [SerializeField] float rango;
    [SerializeField] float cadenciaDeDisparo;

    [Header("Torreta Movimiento")]
    [SerializeField] private float velocidadDeRotacion = 5.0f;
    public Transform parteQueRota;

    [Header("Torreta Disparo")]
    private float timerDeDisparo = 0.0f; 

    [Header("Bala")]
    public GameObject prefavDeBala;
    public Transform puntoDeDisparo;

    [Header("Tiempo De Vida")]
    public Image barradevida;
    public float timeTorre = 100;
    
    void Start()
    {
        //hace que la funcion de ActualizarObjetivo se este llamando desde el segundo 0 y cada 0.5 secs
        InvokeRepeating("ActualizarObjetivo", 0f, 0.5f);
        //activa la barra de vida en el cambas ((cambiar a una que se instancie en el mundo))
        //barradevida.gameObject.SetActive(true);
        //agarra los valores de el So de la torre y los guarda 
        rango = stats.rango;
        cadenciaDeDisparo = stats.cadencia;
    }

    public void ActualizarObjetivo()
    {
        //bsuca todos los gO con el tag de enemigo
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("enemigo");
        float distanciaMasCorta = Mathf.Infinity;
        //setea el enemigo mas cercano en null
        GameObject enemigoMasCercano = null;
        //por cada enemigo hace...
        foreach(GameObject enemigo in enemigos)
        {
            //saca la distancia del enemigo
            float distanciaAEnemigo = Vector3.Distance(transform.position, enemigo.transform.position);
            //si la distranci del enemigo es menor a la distancia mas corata
            if(distanciaAEnemigo < distanciaMasCorta)
            {
                //iguala la distancia mas corta a la distancia mas corta
                distanciaMasCorta = distanciaAEnemigo;
                enemigoMasCercano = enemigo;
            }
        }
        //si no hay enemigo mas cercano..
        if(enemigoMasCercano != null && distanciaMasCorta <= rango)
        {
            //agarra a el siguiente enemigo
            objetivo = enemigoMasCercano.transform;
        }
    }

    void Update()
    {
        //llama-yama a la funcion del desgaste de la torreta
        Desagaste();
        //si no hay un objetivo retorna nada
        if(objetivo == null)
        {
            return;
        }
        //hace la rotacion de la torreta hacia el enemigo
        Vector3 direccionTorreta = objetivo.position - transform.position;
        Quaternion haciaDondeRota = Quaternion.LookRotation(direccionTorreta);
        Vector3 rotacion = Quaternion.Lerp(parteQueRota.rotation, haciaDondeRota, Time.deltaTime * velocidadDeRotacion).eulerAngles;
        parteQueRota.rotation = Quaternion.Euler(0f, rotacion.y, 0f);
        //si se acabo el tiempo de espera para disparar...
        if(timerDeDisparo <= 0f)
        {
            //llama-yama a la funcion de disparo
            Shoot();
            //setea el tiempo de disparo a uno otra vez
            timerDeDisparo = 1f / cadenciaDeDisparo;
        }
        //va reduciedno el tiempo de disparo
        timerDeDisparo -= Time.deltaTime;
    }

    public void Shoot()
    {
        //ibstancia la vala 
        GameObject ataqueBala = (GameObject)Instantiate (prefavDeBala, puntoDeDisparo.position, puntoDeDisparo.rotation);
        Bala bala = ataqueBala.GetComponent<Bala>();
        //si la bala existe...
        if(bala != null)
        {
            //busca a el enemigo
            bala.Buscar(objetivo);
        }
    }
    //es para ver el radio de alcanse de la torreta
    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }

    public void Desagaste()
    {
        //le va quitando 2 de vida por segundo a la torreta
        timeTorre -= 2 * Time.deltaTime;
        //va reduciendo la barra de desgaste de la torreta
        barradevida.fillAmount = timeTorre / 100f;
                        //barradevida.value = currentTime;
        //si el desgaste de la torreta llega a 0 destrulle la torreta y la barra de vida
        if (timeTorre <= 0f)
        {
            barradevida.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
