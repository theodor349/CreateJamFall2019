using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    private void OnEnable()
    {
        FillScoreBoard();
    }

    private void FillScoreBoard()
    {
        if (scoreController.bestSecondsP1 > scoreController.bestSecondsP2)
        {
            winnerName.text = "Player 1";
            winndersSeconds.text = scoreController.bestSecondsP1.ToString();
            winnersMiliSeconds.text = scoreController.bestMiliSecondsP1.ToString();
        }

        else if (scoreController.bestSecondsP1 < scoreController.bestSecondsP2)
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
