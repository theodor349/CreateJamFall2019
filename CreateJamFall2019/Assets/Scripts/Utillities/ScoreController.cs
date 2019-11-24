using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;


    public TextMeshProUGUI scoreTextSeconds;
    public TextMeshProUGUI scoreTextMiliseconds;

    public TextMeshProUGUI bestScoreTextSeconds;
    public TextMeshProUGUI bestScoreTextMiliseconds;
    public TextMeshProUGUI bestScoreName;

    public TextMeshProUGUI currentPlanetPlayerText;

    private double roundTime = 0.0f;
    private int currentSeconds;
    int roundMili;

    public int bestSeconds;
    public int bestMiliSeconds;

    private void Awake()
    {
        Instance = this;
    }


    public void CheckForNewScore()
    {

        if (bestSeconds < currentSeconds || bestSeconds == currentSeconds && bestMiliSeconds < roundMili)
        {

            if (currentSeconds < 10)
                bestScoreTextSeconds.text = "00" + currentSeconds.ToString();

            else if (currentSeconds < 100)
                bestScoreTextSeconds.text = "0" + currentSeconds.ToString();

            else
                bestScoreTextSeconds.text = currentSeconds.ToString();

            bestScoreTextMiliseconds.text = roundMili.ToString();

            bestSeconds = currentSeconds;
            bestMiliSeconds = roundMili;
        }
    }

    public void ResetRoundTime()
    {
        roundTime = 0;
        currentSeconds = 0;
    }


    private void CountRoundTime()
    {
        roundTime += Time.deltaTime;

        roundMili = (int)(roundTime * 1000);

        if ( roundMili >= 1000)
        {
            currentSeconds ++;
            roundTime = 0;
            roundMili = 0;
        }

        if (roundMili < 100)
            scoreTextMiliseconds.text = "0" + roundMili.ToString();

        else
            scoreTextMiliseconds.text = roundMili.ToString();

        scoreTextSeconds.text = currentSeconds.ToString();

    }



    void Update()
    {
        CountRoundTime();
    }
}
