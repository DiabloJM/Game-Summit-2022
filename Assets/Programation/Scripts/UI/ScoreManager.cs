using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int scoreValue = 0;
    static Text Score;

    void Start()
    {
        Score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() //Cuando se gane Score matando enemigos, remplazar esta función por UpdateScore
    {
        Score.text = "Money: " + scoreValue;
        
        /*if(Input.GetKeyDown(KeyCode.KeypadPlus)) //Para testeos
            addScore();*/
        if (scoreValue <= 0)
            scoreValue = 0;
    }

    public void addScore()
    {
        scoreValue += 100;
    }

    public static void UpdateScore() //De momento no haces nada pana
    {
        if (scoreValue <= 0)
            scoreValue = 0;
        Score.text = "Money: " + scoreValue;
    }
}
