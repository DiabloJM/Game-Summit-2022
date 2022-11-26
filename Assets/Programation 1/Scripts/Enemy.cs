using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    GamePlayLoop ciclo2;

    void Start()
    {
        ciclo2 = FindObjectOfType<GamePlayLoop>();
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Bullet":
                Debug.Log("Win");
                ciclo2.ShowWinScreen();

                break;
        }
    }
}
