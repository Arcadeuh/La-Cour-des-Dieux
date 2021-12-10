using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ScoreProgress : MonoBehaviour
{
    public int scorePlayer1 = 0;
    public int scorePlayer2 = 0;
    private int roundNb = 1;
    private int victoryCountP1 = 0;
    private int victoryCountP2 = 0;

    private bool player1Alive = true;
    private bool player2Alive = true;

    [SerializeField] private UnityEvent player1WinRound;
    [SerializeField] private UnityEvent player2WinRound;
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
    [SerializeField] private Image backgroundImage;
    private AudioManager audioManager;

    private Sprite backgroundScore0;
    private Sprite backgroundScore1;
    private Sprite backgroundScore2;

    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private float magnitude = 0.5f;




    private void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        backgroundScore0 = Resources.Load<Sprite>("Backgrounds/Nebula Aqua-Pink");
        backgroundScore1 = Resources.Load<Sprite>("Backgrounds/Nebula Blue");
        backgroundScore2  = Resources.Load<Sprite>("Backgrounds/Nebula Red");


        reDrawUI();
    }


    public Gamepad vibratingGamepad;

    public void killPlayer(string playerName)
    {
        audioManager.Play("Hurt");      // play sound
        StartCoroutine(cameraShake.Shake(duration, magnitude));

        if (player1.name == playerName)
        {
            player1Alive = false;
            scorePlayer2++;
            if (scorePlayer2 >= 3)
            {
                victoryCountP2++;
                SaveSystem.SaveRoundsData(victoryCountP1, victoryCountP2);

                if (victoryCountP2 >= 3)
                {
                    onVictoryP2.Invoke();
                    matchWin.SetActive(true);
                    matchWin.GetComponent<TMP_Text>().SetText("Player 2 est le dieu de cette cour !");
                    audioManager.StopEverySounds();
                    audioManager.Play("Victory");
                    return;
                }
                reDrawUI();
                win(player2.name);
                player2WinRound.Invoke();
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
                    matchWin.GetComponent<TMP_Text>().SetText("Player 1 est le dieu de cette cour !");
                    audioManager.StopEverySounds();
                    audioManager.Play("Victory");
                    return;
                }
                reDrawUI();
                win(player1.name);
                player1WinRound.Invoke();
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
        if (backgroundImage.sprite == null)
        {
            switch (Mathf.Max(victoryCountP1, victoryCountP2))
            {
                case 0:
                    backgroundImage.sprite = backgroundScore0;
                    break;
                case 1:
                    backgroundImage.sprite = backgroundScore1;
                    break;
                case 2:
                    backgroundImage.sprite = backgroundScore2;
                    break;
            }
        }
        victoryPointsP1.UpdateUI();
        victoryPointsP2.UpdateUI();
        UIScore.GetComponentInChildren<UnityEngine.UI.Text>().text = scorePlayer1 + " : " + scorePlayer2;
        UIRound.GetComponentInChildren<UnityEngine.UI.Text>().text = "Round " + roundNb;
    }

    public void win(string playerName)
    {
        UIWin.GetComponentInChildren<UnityEngine.UI.Text>().text = playerName + " a gagné ce round";
        //SceneManager.LoadScene("DeckBuildingQuentin");
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

    public void ExchangePlayers()
    {
        if(player1.name == "Player1" && player2.name == "Player2") { return; }
        GameObject playerTemp = player1;
        player1 = player2;
        player2 = playerTemp;
    }

    public IEnumerator InvincibleTimeAndRumble(UnityEngine.InputSystem.Gamepad playerGamepad)
    {
        vibratingGamepad = playerGamepad;
        playerGamepad.SetMotorSpeeds(0.1f, 0.2f);
        yield return new WaitForSeconds(1.5f);
        playerGamepad.SetMotorSpeeds(0, 0);
    }
}
