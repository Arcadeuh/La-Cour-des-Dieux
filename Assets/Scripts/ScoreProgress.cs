using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreProgress : MonoBehaviour
{
    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;
    private int roundNb = 1;
   

    private bool player1Alive = true;
    private bool player2Alive = true;

    public GameObject player1;
    public GameObject player2;
    public GameObject UIScore;
    public GameObject UIRound;
    public GameObject UIWin;


    public void killPlayer(string playerName)
    {
        
        if (player1.name == playerName)
        {
            player1Alive = false;
            scorePlayer2++;
            if (scorePlayer2 >= 3)
            {
                roundNb++;
                reDrawUI();
                win(player2.name);
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
                roundNb++;
                reDrawUI();
                win(player1.name);
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
        
        UIScore.GetComponentInChildren<UnityEngine.UI.Text>().text = scorePlayer1 + " : " + scorePlayer2;
        UIRound.GetComponentInChildren<UnityEngine.UI.Text>().text = "Round " + roundNb;
    }

    public void win(string playerName)
    {
        UIWin.GetComponentInChildren<UnityEngine.UI.Text>().text = playerName + " Won This Round";
        SceneManager.LoadScene("DeckBuildingQuentin");
    }

}
