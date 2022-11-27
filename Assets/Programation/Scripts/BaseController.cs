using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    [SerializeField] int vida;

    [SerializeField] GameManager _GameManager;
    [SerializeField] UI_Manager _UIManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0)
        {
            //Call UI Manager for Game Over screen
        }
    }

    //Llamado para reposicionar la base entre las posiciones posibles
    void ReposicionarBase(/*Podemos hacer un input para que el Manager calcule las posiciones y solo se la entregue a la base*/)
    {
        //Hacer proceso para reposicionar base
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemigo")
        {
            vida--;
            Debug.Log("Collision de Base: Enemigo");
        }
    }
}
