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

    private Vector3 lastPosition;


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

        Vector3 screen = Camera.main.WorldToScreenPoint(transform.position);
        float distX = Vector3.Distance(new Vector3(Screen.width / 2, 0f, 0f), new Vector3(screen.x, 0f, 0f));
        float distY = Vector3.Distance(new Vector3(0f, Screen.height / 2, 0f), new Vector3(0f, screen.y, 0f));

        // rotate the player with stick
        float targetAngle = transform.eulerAngles.y;

        if (rotate.sqrMagnitude >= 0.015f)
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
        if (move.sqrMagnitude >= 0.1f)
        { 
            if (distX > Screen.width / 2 || distY > Screen.height / 2)
            {
                controller.transform.position = lastPosition;
            }
            
            else
            {
                lastPosition = transform.position;
                controller.Move(direction * speed * Time.deltaTime);
            }

        }


    }
}
