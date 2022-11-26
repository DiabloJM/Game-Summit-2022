using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControl : MonoBehaviour
{
    public float angulo;
    private void Update()
    {
        //Obtenemos la posicion de la torre en la pantalla
        Vector2 posicionEnPantalla = Camera.main.WorldToViewportPoint(transform.position);
        //Obtenemos la posicion del mouse en la pantalla
        Vector2 mouseEnPantalla = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //Obtenemos el ángulo entre la torre y el mouse
        angulo = AnguloEntrePuntos(posicionEnPantalla, mouseEnPantalla);
        //Limitar el ángulo de rotacion
        
        if(angulo > 25.0f)
        {
            angulo = 25.0f;
        }

        if(angulo < -165.0f)
        {
            angulo = -165.0f;
        }
        
        //Modificamos la rotacion de la torre
        transform.rotation = Quaternion.Euler(new Vector3(0f, -angulo, 0f));
    }

    //Funcion para obtener el ángulo entre dos puntos
    private float AnguloEntrePuntos(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
