using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    GamePlayLoop ciclo;


     void Start()
    {
        ciclo = FindObjectOfType<GamePlayLoop>();    
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                Debug.Log("GameOver");
                ciclo.ShowGameOver();
                
                break;
        }
    }

    
}
