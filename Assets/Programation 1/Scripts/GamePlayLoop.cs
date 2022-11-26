using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayLoop : MonoBehaviour
{
    public GameObject gameOverPanel; //Text


    void Start()
    {
        gameOverPanel.gameObject.SetActive(false);

    }

    public void ShowGameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
    }
}
