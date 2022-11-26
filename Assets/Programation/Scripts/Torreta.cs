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
    public Slider barradevida;
    public float currentTime;
    
    void Start()
    {
        //hace que la funcion de ActualizarObjetivo se este llamando desde el segundo 0 y cada 0.5 secs
        InvokeRepeating("ActualizarObjetivo", 0f, 0.5f);
        //activa la barra de vida en el cambas ((cambiar a una que se instancie en el mundo))
        barradevida.gameObject.SetActive(true);
        //agarra los valores de el So de la torre y los guarda 
        rango = stats.rango;
        cadenciaDeDisparo = stats.cadencia;
    }

    public void ActualizarObjetivo()
    {
        //buaca todos los gO con el tag de enemigo
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("enemigo");
        float distanciaMasCorta = Mathf.Infinity;
        GameObject enemigoMasCercano = null;
        foreach(GameObject enemigo in enemigos)
        {
            float distanciaAEnemigo = Vector3.Distance(transform.position, enemigo.transform.position);
            if(distanciaAEnemigo < distanciaMasCorta)
            {
                distanciaMasCorta = distanciaAEnemigo;
                enemigoMasCercano = enemigo;
            }
        }
        if(enemigoMasCercano != null && distanciaMasCorta <= rango)
        {
            objetivo = enemigoMasCercano.transform;
        }
    }

    void Update()
    {

        currentTime -= 1 * Time.deltaTime;
        barradevida.value = currentTime;

        if (currentTime <= 0f)
        {
            barradevida.gameObject.SetActive(false);
            Destroy(gameObject);
        }

        if(objetivo == null)
        {
            return;
        }

        Vector3 direccionTorreta = objetivo.position - transform.position;
        Quaternion haciaDondeRota = Quaternion.LookRotation(direccionTorreta);
        Vector3 rotacion = Quaternion.Lerp(parteQueRota.rotation, haciaDondeRota, Time.deltaTime * velocidadDeRotacion).eulerAngles;
        parteQueRota.rotation = Quaternion.Euler(0f, rotacion.y, 0f);

        if(timerDeDisparo <= 0f)
        {
            Shoot();
            timerDeDisparo = 1f / cadenciaDeDisparo;
        }
        timerDeDisparo -= Time.deltaTime;
    }

    public void Shoot()
    {
        GameObject ataqueBala = (GameObject)Instantiate (prefavDeBala, puntoDeDisparo.position, puntoDeDisparo.rotation);
        Bala bala = ataqueBala.GetComponent<Bala>();
        if(bala != null)
        {
            bala.Buscar(objetivo);
        }
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}
