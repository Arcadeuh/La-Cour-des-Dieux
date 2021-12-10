using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LoadController : MonoBehaviour
{
    [SerializeField] private GameObject playerA;
    [SerializeField] private GameObject playerB;
    [SerializeField] private ScoreProgress scoreProgress;

    // Start is called before the first frame update
    void Awake()
    {

        AudioListener.volume = PlayerPrefs.GetFloat("volume");

        ControllerData cd = SaveSystem.LoadControllerData();
        if (cd == null) { Debug.LogError("Pas de controllers sauvegardés"); return; }

        InputDevice inputDevice = playerA.GetComponent<PlayerInput>().devices[0];
        Gamepad presentGamepad = (Gamepad)InputSystem.GetDeviceById(inputDevice.deviceId);

        if (cd.controllerP1 == presentGamepad.name)
        {
            Debug.Log("Player 1");
            playerA.name = "Player1";
            playerB.name = "Player2";
            playerA.transform.position = new Vector3(-8.15f, playerA.transform.position.y, playerA.transform.position.z);
            playerB.transform.position = new Vector3(8.15f, playerB.transform.position.y, playerB.transform.position.z);
            TokenManager tokenManager = null;
            if (playerA.TryGetComponent<TokenManager>(out tokenManager)) { tokenManager.playerId = 1; Debug.Log(playerA.name + " : " + tokenManager.playerId); }
            if (playerB.TryGetComponent<TokenManager>(out tokenManager)) { tokenManager.playerId = 2; Debug.Log(playerB.name + " : " + tokenManager.playerId); }
        }
        else if (cd.controllerP2 == presentGamepad.name)
        {
            playerA.name = "Player2";
            playerB.name = "Player1";
            playerA.transform.position = new Vector3(8.15f, playerA.transform.position.y, playerA.transform.position.z);
            playerB.transform.position = new Vector3(-8.15f, playerB.transform.position.y, playerB.transform.position.z);
            TokenManager tokenManager = null;
            if (playerA.TryGetComponent<TokenManager>(out tokenManager)) { tokenManager.playerId = 2; Debug.Log(playerA.name + " : " + tokenManager.playerId); }
            if (playerB.TryGetComponent<TokenManager>(out tokenManager)) { tokenManager.playerId = 1; Debug.Log(playerB.name + " : " + tokenManager.playerId); }
        }
        if (scoreProgress)
        {
            scoreProgress.ExchangePlayers();
        }
    }
}
