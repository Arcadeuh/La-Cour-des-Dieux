using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class BastienTests : MonoBehaviour
{
    public void PrintFunction()
    {
        Debug.Log("PrintFunction()");
    }

    public void InputJoystick()
    {
        Debug.Log(Joystick.all[0].deviceId);
    }

    private void Update()
    {

    }
}
