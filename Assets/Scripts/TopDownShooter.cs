using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TopDownShooter : MonoBehaviour
{

    public void OnRightTrigger(InputAction.CallbackContext context)
    {
        Debug.Log("Fire");
    }

}
