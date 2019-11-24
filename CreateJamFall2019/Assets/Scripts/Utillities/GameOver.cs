using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private ScoreController scoreController;

    public TextMeshProUGUI winnerName;
    public TextMeshProUGUI winndersSeconds;
    public TextMeshProUGUI winnersMiliSeconds;

    [SerializeField]
    private GameObject[] objectsToHide;

    private void Start()
    {
        scoreController = ScoreController.Instance;
    }

    private void Update()
    {
        if (Input.anyKey)
            Application.LoadLevel(Application.loadedLevel);
    }

    private void OnEnable()
    {
        FillScoreBoard();
    }

    private void FillScoreBoard()
    {
        if(scoreController == null)
            scoreController = ScoreController.Instance;
        
        if (scoreController.bestSecondsP1 + scoreController.bestMiliSecondsP1 / 1000f > scoreController.bestSecondsP2 + scoreController.bestMiliSecondsP2 / 1000f)
        {
            winnerName.text = "Player 1";
            winndersSeconds.text = scoreController.bestSecondsP1.ToString();
            winnersMiliSeconds.text = scoreController.bestMiliSecondsP1.ToString();
        }
        else if (scoreController.bestSecondsP1 + scoreController.bestMiliSecondsP1 / 1000f < scoreController.bestSecondsP2 + scoreController.bestMiliSecondsP2 / 1000f)
        {
            winnerName.text = "Player 2";
            winndersSeconds.text = scoreController.bestSecondsP2.ToString();
            winnersMiliSeconds.text = scoreController.bestMiliSecondsP2.ToString();
        }
        else
        {
            winnerName.text = "Its a draw";
            winndersSeconds.text = scoreController.bestSecondsP1.ToString();
            winnersMiliSeconds.text = scoreController.bestMiliSecondsP1.ToString();
        }

    }


    private void HideObjects()
    {
        for(int i = 0; i < objectsToHide.Length; i++)
        {
            objectsToHide[i].SetActive(false);
        }
    }
}
