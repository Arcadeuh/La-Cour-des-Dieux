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
    public float speed = 6f;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Gameplay.Move.performed += ctx => move = ctx.ReadValue<Vector2>(); // on met la valeur dans la variable move
        controls.Gameplay.Move.canceled += ctx => move = Vector2.zero;
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

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, targetAngle, 0.0f);

            controller.Move(direction * speed * Time.deltaTime);
        }

    }
}
