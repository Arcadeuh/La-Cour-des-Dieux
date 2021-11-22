using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ScoreProgress : MonoBehaviour
{
    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;
    private int roundNb = 1;
    private int victoryCountP1 = 0;
    private int victoryCountP2 = 0;

    private bool player1Alive = true;
    private bool player2Alive = true;

    [SerializeField] private UnityEvent onPlayer1Win;
    [SerializeField] private UnityEvent onPlayer2Win;
    [SerializeField] private UnityEvent onVictoryP1;
    [SerializeField] private UnityEvent onVictoryP2;
    public GameObject player1;
    public GameObject player2;
    public GameObject UIScore;
    public GameObject UIRound;
    public GameObject UIWin;
    public GameObject matchWin;
    [SerializeField] private VictoryPoints victoryPointsP1;
    [SerializeField] private VictoryPoints victoryPointsP2;


    public void killPlayer(string playerName)
    {
        
        if (player1.name == playerName)
        {
            player1Alive = false;
            scorePlayer2++;
            if (scorePlayer2 >= 3)
            {
                //roundNb++;
                victoryCountP2++;
                SaveSystem.SaveRoundsData(victoryCountP1, victoryCountP2);

                if (victoryCountP2 >= 3)
                {
                    onVictoryP2.Invoke();
                    matchWin.SetActive(true);
                    matchWin.GetComponent<TMP_Text>().SetText("Player 2 Wins !!");
                    return;
                }
                reDrawUI();
                win(player2.name);
                onPlayer2Win.Invoke();
            }
            else
            {
                reDrawUI();
                /*
                player1 = Instantiate<GameObject>(player1);
                player1.name = playerName;
                */
            }
        }
        if (player2.name == playerName)
        {
            player2Alive = false;
            scorePlayer1++;
            if (scorePlayer1 >= 3)
            {
                //roundNb++;
                victoryCountP1++; 
                SaveSystem.SaveRoundsData(victoryCountP1, victoryCountP2);

                if (victoryCountP1 >= 3)
                {
                    onVictoryP1.Invoke();
                    matchWin.SetActive(true);
                    matchWin.GetComponent<TMP_Text>().SetText("Player 1 Wins !!");
                    return;
                }
                reDrawUI();
                win(player1.name);
                onPlayer1Win.Invoke();
            }
            else
            {
                reDrawUI();
                /*
                player2 = Instantiate<GameObject>(player2);
                player2.name = playerName;
                */
            }
        }

    }

    public void reDrawUI()
    {
        victoryPointsP1.SetVictoryPoints(victoryCountP1);
        victoryPointsP2.SetVictoryPoints(victoryCountP2);
        victoryPointsP1.UpdateUI();
        victoryPointsP2.UpdateUI();
        UIScore.GetComponentInChildren<UnityEngine.UI.Text>().text = scorePlayer1 + " : " + scorePlayer2;
        UIRound.GetComponentInChildren<UnityEngine.UI.Text>().text = "Round " + roundNb;
    }

    public void win(string playerName)
    {
        UIWin.GetComponentInChildren<UnityEngine.UI.Text>().text = playerName + " Won This Round";
    }

    public void SetVictoriesNumber(int p1, int p2)
    {
        victoryCountP1 = p1;
        victoryCountP2 = p2;
    }

    public void SetRoundNumber(int n)
    {
        roundNb = n;
        reDrawUI();
    }
}
