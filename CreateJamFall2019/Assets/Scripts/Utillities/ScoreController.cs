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

    public TextMeshProUGUI bestScoreTextSecondsP1;
    public TextMeshProUGUI bestScoreTextMilisecondsP1;

    public TextMeshProUGUI bestScoreTextSecondsP2;
    public TextMeshProUGUI bestScoreTextMilisecondsP2;

    public GameObject gameOverMenu;

    private double roundTime = 0.0f;
    private double roundTimeP1 = 0.0f;
    private double roundTimeP2 = 0.0f;
    private int currentSeconds;
    int roundMili;

    private int roundMiliP1;
    private int currentSecondsP1;
    private int roundMiliP2;
    private int currentSecondsP2;

    public int bestSecondsP1;
    public int bestMiliSecondsP1;
    public int bestSecondsP2;
    public int bestMiliSecondsP2;

    private void Awake()
    {
        Instance = this;
    }

    public void CheckForNewScore(bool isPlayer1)
    {


        if (isPlayer1 == false)
        {
            if (bestSecondsP2 < currentSecondsP2 || bestSecondsP2 == currentSecondsP2 && bestMiliSecondsP2 < roundMiliP2)
            {

                if (currentSecondsP2 < 10)
                    bestScoreTextSecondsP2.text = "00" + currentSecondsP2.ToString();

                else if (currentSecondsP2 < 100)
                    bestScoreTextSecondsP2.text = "0" + currentSecondsP2.ToString();

                else
                    bestScoreTextSecondsP2.text = currentSeconds.ToString();

                bestScoreTextMilisecondsP2.text = roundMiliP2.ToString();

                bestSecondsP2 = currentSeconds;
                bestMiliSecondsP2 = roundMiliP2;
            }
        }

        else
        {
            if (bestSecondsP1 < currentSecondsP1 || bestSecondsP1 == currentSecondsP1 && bestMiliSecondsP1 < roundMiliP1)
            {

                if (currentSecondsP1 < 10)
                    bestScoreTextSecondsP1.text = "00" + currentSecondsP1.ToString();

                else if (currentSecondsP1 < 100)
                    bestScoreTextSecondsP1.text = "0" + currentSecondsP1.ToString();

                else
                    bestScoreTextSecondsP1.text = currentSeconds.ToString();

                bestScoreTextMilisecondsP1.text = roundMiliP1.ToString();

                bestSecondsP1 = currentSeconds;
                bestMiliSecondsP1 = roundMiliP1;
            }
        }





    }

    public void ResetRoundTime(bool isPlayer1)
    {

        if (isPlayer1 == false)
        {
            roundMiliP2 = 0;
            currentSecondsP2 = 0;
        }

        else
        {
            roundMiliP1 = 0;
            currentSecondsP1 = 0;
        }


    }


    private void CountRoundTime()
    {
        roundTime += Time.deltaTime;
        roundTimeP1 += Time.deltaTime;
        roundTimeP2 += Time.deltaTime;

        roundMili = (int)(roundTime * 1000);
        roundMiliP1 = (int)(roundTimeP1 * 1000);
        roundMiliP2 = (int)(roundTimeP2 * 1000);

        if ( roundMili >= 1000)
        {
            currentSeconds++;
            roundTime = 0;
            roundMili = 0;

            if (currentSeconds == 10)
            {
                Vector3 newPostion = new Vector3();
                newPostion = scoreTextSeconds.gameObject.transform.parent.localPosition;
                newPostion.x = 103.5f;
                scoreTextSeconds.gameObject.transform.parent.localPosition = newPostion;
            }

            if (currentSeconds == 100)
            {
                Vector3 newPostion = new Vector3();
                newPostion = scoreTextSeconds.gameObject.transform.parent.localPosition;
                newPostion.x = 110.1f;
                scoreTextSeconds.gameObject.transform.parent.localPosition = newPostion;
            }


        }

        if (roundMiliP1 >= 1000)
        {
            currentSecondsP1++;
            roundTimeP1 = 0;
            roundMiliP1 = 0;
        }

        if (roundMiliP2 >= 1000)
        {
            currentSecondsP2++;
            roundTimeP2 = 0;
            roundMiliP2 = 0;
        }

        if (roundMili < 100)
            scoreTextMiliseconds.text = "0" + roundMili.ToString();

        else
            scoreTextMiliseconds.text = roundMili.ToString();

        scoreTextSeconds.text = currentSeconds.ToString();

    }

    void EndGame()
    {
        gameOverMenu.SetActive(true);
    }

    void Update()
    {
        if (currentSeconds < 180) 
            CountRoundTime();
        else 
            EndGame();
    }
}
