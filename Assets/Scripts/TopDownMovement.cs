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
    public PlayerControls controls;
    public CharacterController controller;

    public Vector2 move;
    public Vector2 rotate;

    public float speed = 6f;

    private float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private void Awake()
    {
        controls = new PlayerControls();

        // Left Stick for movement
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>(); // on met la valeur dans la variable move
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;

        // Right Stick for rotation
        controls.Gameplay.Rotate.performed += ctx => rotate = ctx.ReadValue<Vector2>(); // on met la valeur dans la variable rotate
    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(move.x, 0.0f, move.y).normalized;
        Vector3 rotation = new Vector3(rotate.x, 0.0f, rotate.y).normalized;


        if (rotate.sqrMagnitude >= 0.015f)
        {
            float targetAngle = Mathf.Atan2(rotation.x, rotation.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        }

        if(move.sqrMagnitude >= 0.1f)
        {
            controller.Move(direction * speed * Time.deltaTime);
        }


    }
}
