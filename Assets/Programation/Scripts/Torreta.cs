using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    [Header("Torreta")]
    public Transform objetivo;
    [SerializeField]
    private float rango = 15f;
    //public string enemigoTag = "enemigo";
    
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
    }

    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}
