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


    public float speed = 6f;

    private Vector2 move;
    private Vector2 rotate;
    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    //Setters and getters included in variables
    public Vector2 Move { get => move; set => move = value; }
    public Vector2 Rotate { get => rotate; set => rotate = value; }

    public void OnMove(InputAction.CallbackContext context)
    {
        Move = context.ReadValue<Vector2>();
    }

    public void OnRotate(InputAction.CallbackContext context)
    {
        Rotate = context.ReadValue<Vector2>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(Move.x, 0.0f, Move.y).normalized;
        Vector3 rotation = new Vector3(Rotate.x, 0.0f, Rotate.y).normalized;


        // rotate the player with stick
        float targetAngle = transform.eulerAngles.y;

        if (Rotate.sqrMagnitude >= 0.015f)
        {
            targetAngle = Mathf.Atan2(rotation.x, rotation.z) * Mathf.Rad2Deg;
        }
        else if(direction.magnitude>=0.1f)
        {
            targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        }

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);

        // Move the player
        if(Move.sqrMagnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }


    }
}
