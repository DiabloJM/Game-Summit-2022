using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{


    [Header("Caracteristicas")] //Datos del 
    [SerializeField] int vida;
    [SerializeField] float velocidad;

    [Header("Referencias")]   
    [SerializeField] StatsEnemigos statData; //Referencia a tabla de datos con caracteristicas del enemigo
    UnityEngine.AI.NavMeshAgent navAgent;
    [SerializeField] GameManager manager;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        //Setup data values
        vida = statData.vida;
        velocidad = statData.velocidad;


        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        navAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        navAgent.speed = velocidad;

        manager.enemigosEnJuego++;
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Basico": //Colisiona con un proyectil basico
                vida -= 15;
            break;

            case "Rango": //Proyectil de Torre de rango
                vida -= 50;
            break;

            case "Area":    //Proyectil de torre de area
                vida -= 30;
            break;
            
            case "Base":
                Destroy(gameObject);
                manager.vidaBase--;
                manager.enemigosEnJuego--;
                break;

            default:
                Debug.Log("Enemy: No valid tag");
            break;
        }

        //Si la vida es menor o igual a 0 destruye el enemigo
        if (vida <= 0)
        {
            Destroy(this.gameObject);
            manager.enemigosEnJuego--;
        }
    }
}
