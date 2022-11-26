using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{

    private Transform objetivo;

    public float velocidadBala = 50f;

    public void Buscar(Transform _objetivo)
    {
        objetivo = _objetivo;
    }
    
    void Update()
    {
        if(objetivo == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direccion = objetivo.position - transform.position;
        float distanciaEsteFrame = velocidadBala * Time.deltaTime;

        if(direccion.magnitude <= distanciaEsteFrame)
        {
            GolpeEnemigo();
            return;
        }

        transform.Translate(direccion.normalized * distanciaEsteFrame, Space.World);

    }

    public void GolpeEnemigo()
    {
        Debug.Log("GolpeEnemigo");
    }

}
