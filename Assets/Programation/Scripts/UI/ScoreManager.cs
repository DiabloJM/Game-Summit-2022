using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int scoreValue = 500; // static int
    public int score1;
    Text Score;
    public Dinero dineroSo;

    void Start()
    {
        Score = GetComponent<Text>();
        scoreValue = dineroSo.dinero;
    }

    // Update is called once per frame
    void Update()
    {
       
        Score.text = "Dinero " + scoreValue;
        
        /*if(Input.GetKeyDown(KeyCode.KeypadPlus)) //Para testeos
            addScore();*/
        if (scoreValue <= 0)
        {
            scoreValue = 0;
        }
    }

    public static void addScore() // static
    {
        scoreValue += 50;
    }

    public void setToZero()
    {
        scoreValue = 500;
    }
}
