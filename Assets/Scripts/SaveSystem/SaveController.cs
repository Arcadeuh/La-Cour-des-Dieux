using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SaveController : MonoBehaviour
{
    [SerializeField] private PlayerInput player1;
    [SerializeField] private PlayerInput player2;

    public void SavePlayersController()
    {
        InputDevice inputDevice = player1.devices[0];
        Gamepad p1Gamepad = (Gamepad)InputSystem.GetDeviceById(inputDevice.deviceId);
        inputDevice = player2.devices[0];
        Gamepad p2Gamepad = (Gamepad)InputSystem.GetDeviceById(inputDevice.deviceId);
        SaveSystem.SaveControllerData(p1Gamepad.name, p2Gamepad.name);
    }
}
