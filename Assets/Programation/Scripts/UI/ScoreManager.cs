using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int scoreValue = 0;
    Text Score;

    void Start()
    {
        Score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Score.text = "Money: " + scoreValue;
        
        if(Input.GetKeyDown(KeyCode.KeypadPlus)) //Para testeos
            addScore();
        if (scoreValue <= 0)
        {
            scoreValue = 0;
        }
    }

    public void addScore()
    {
        scoreValue += 100;
    }

    public void setToZero()
    {
        scoreValue = 0;
    }
}
