using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LoadController : MonoBehaviour
{
    [SerializeField] private GameObject playerA;
    [SerializeField] private GameObject playerB;

    // Start is called before the first frame update
    void Awake()
    {
        ControllerData cd = SaveSystem.LoadControllerData();
        if (cd == null) { Debug.LogError("Pas de controllers sauvegardés"); return; }

        InputDevice inputDevice = playerA.GetComponent<PlayerInput>().devices[0];
        Gamepad presentGamepad = (Gamepad)InputSystem.GetDeviceById(inputDevice.deviceId);

        if (cd.controllerP1 == presentGamepad.name)
        {
            playerA.name = "Player1";
            playerB.name = "Player2";
            playerA.transform.position = new Vector3(-200, 0, 0);
            playerB.transform.position = new Vector3(200, 0, 0);
            TokenManager tokenManager = null;
            if (playerA.TryGetComponent<TokenManager>(out tokenManager)) { tokenManager.playerId = 1; }
            if (playerB.TryGetComponent<TokenManager>(out tokenManager)) { tokenManager.playerId = 2; }
        }
        else if (cd.controllerP2 == presentGamepad.name)
        {
            playerA.name = "Player2";
            playerB.name = "Player1";
            playerA.transform.position = new Vector3(200, 0, 0);
            playerB.transform.position = new Vector3(-200, 0, 0);
            TokenManager tokenManager = null;
            if (playerA.TryGetComponent<TokenManager>(out tokenManager)){ tokenManager.playerId = 2; }
            if (playerB.TryGetComponent<TokenManager>(out tokenManager)) { tokenManager.playerId = 1; }
        }
    }
}
