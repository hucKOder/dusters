using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreTmp;

    public TextMeshProUGUI highScoreTmp;
    // Start is called before the first frame update
    void Start()
    {
        var score = Mathf.FloorToInt(PlayerPrefs.GetFloat("score"));
        var highScore = Mathf.FloorToInt(PlayerPrefs.GetFloat("highScore"));
        if (score > highScore)
        {
            PlayerPrefs.SetFloat("highScore", PlayerPrefs.GetFloat("score"));
            highScore = score;
        }
        
        scoreTmp.text = "Score: " + score;
        highScoreTmp.text = "High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
