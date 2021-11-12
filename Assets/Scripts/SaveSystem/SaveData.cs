using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Objet contenant ce qui doit être sauvegarder
 */
[System.Serializable]
public class SaveData
{
    public Deck deckPlayer1;
    public Deck deckPlayer2;

    public SaveData(Deck p1, Deck p2)
    {
        deckPlayer1 = p1;
        deckPlayer2 = p2;
    }

    public void SetPlayersController(PlayerInput playerInput)
    {
        InputDevice playerDevice = playerInput.devices[0];
        Gamepad gamepad = (Gamepad)InputSystem.GetDeviceById(playerDevice.deviceId);
    }
}
