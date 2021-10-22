/*
 * Component a ajouter a un objet que l'on souhaite deplacer a l'aide d'input
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TopDownMovement : MonoBehaviour
{
    public CharacterController controller;

    public Vector2 move;
    public Vector2 rotate;

    public float speed = 6f;

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;


    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        rotate = context.ReadValue<Vector2>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(move.x, 0.0f, move.y).normalized;
        Vector3 rotation = new Vector3(rotate.x, 0.0f, rotate.y).normalized;


        // rotate the player
        if (rotate.sqrMagnitude >= 0.015f)
        {
            float targetAngle = Mathf.Atan2(rotation.x, rotation.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        }

        // Move the player
        if(move.sqrMagnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }


    }
}
