using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    [Header("Enemigo")]
    private Transform objetivo;

    [Header("Torreta Movimiento")]
    [SerializeField] private float rango = 15f;
    [SerializeField] private float velocidadDeRotacion = 5.0f;
    public Transform parteQueRota;

    [Header("Torreta Disparo")]
    public float cadenciaDeDisparo = 1.0f;
    private float timerDeDisparo = 0.0f; 

    [Header("Bala")]
    public GameObject prefavDeBala;
    public Transform puntoDeDisparo;
    
    void Start()
    {
        InvokeRepeating("ActualizarObjetivo", 0f, 0.5f);
    }

    public void ActualizarObjetivo()
    {
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
