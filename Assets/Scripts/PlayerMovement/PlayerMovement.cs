using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody playerRb;
    private Vector3 direction;

    public float playerSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.Translate(direction * playerSpeed * Time.deltaTime);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>() * playerSpeed;
        direction = new Vector3(inputVector.x,0,inputVector.y);

        // Code that moves the player based on the direction
    }
}
