using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameScore : MonoBehaviour
{

    Text scoreTextUI;

    int score;

    public int Score
    {
        get
        {
            return this.score;
        }
        
        set 
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        scoreTextUI = GetComponent<Text>();
    }

    void UpdateScoreTextUI()
    {
        string scoreStr = string.Format("{0:0000000}", score);
        scoreTextUI.text = scoreStr;

    }
}
