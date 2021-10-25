using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TopDownShooter : MonoBehaviour
{
    public GameObject planet;


    public void OnRightTrigger(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid()) { return; }    // avoid to create things with Player Input manager

        if (context.performed )
        {
            if (planet)
            {
                Instantiate(planet, transform.position + transform.forward, Quaternion.identity);
            }
        }

    }

}
