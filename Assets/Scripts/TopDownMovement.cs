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
    public CharacterController controller;  // controller (utilise pour calibrer les sticks)

    public Vector2 move;    // Movement of the player
    public Vector2 rotate;  // rotation of the player

    public float speed = 6f;    // vitesse de movement 

    private GameObject planetAttached = null; // planete selectionne
    public GameObject PlanetAttached { get => planetAttached; set => planetAttached = value; }


    private float turnSmoothTime = 0.1f;    // Smooth the rotation with lerp
    private float turnSmoothVelocity;       // velocity de la rotation 

    private Vector3 lastPosition;


    public void OnMove(InputAction.CallbackContext context)     // Input on left sitck for move
    {
        move = context.ReadValue<Vector2>();    // recup le stick
    }

    public void OnRotate(InputAction.CallbackContext context)   // Input right stick for rotate
    {
        rotate = context.ReadValue<Vector2>();  // recup le stick
    }


    // Update is called once per frame
    void Update()
    {
        RotatePlayer(); // rotate the player with stick
        MovePlayer(); // Move the player
        MovePlanetIfAttached();
    }

    private void RotatePlayer(){
        Vector3 direction = new Vector3(move.x, 0.0f, move.y).normalized;       // normalise la direction
        Vector3 rotation = new Vector3(rotate.x, 0.0f, rotate.y).normalized;    // normalise la rotation
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
    }

    private void MovePlayer(){
        Vector3 direction = new Vector3(move.x, 0.0f, move.y).normalized;       // normalise la direction
        Vector3 screen = Camera.main.WorldToScreenPoint(transform.position);    // position de l'écran
        float distX = Vector3.Distance(new Vector3(Screen.width / 2, 0f, 0f), new Vector3(screen.x, 0f, 0f));   // dist en X de l'ecran
        float distY = Vector3.Distance(new Vector3(0f, Screen.height / 2, 0f), new Vector3(0f, screen.y, 0f));  // dist en Y de l'ecran

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

    public void MovePlanetIfAttached()
    {
        if (planetAttached)
        {
            planetAttached.transform.position = transform.position + transform.forward * 2.5f;
        }
    }

    public void attach(GameObject planet)
    {
        planetAttached = planet;
        planetAttached.GetComponent<SphereCollider>().enabled = false;
    }

    public void detach()
    {
        if (planetAttached)
        {
            planetAttached.GetComponent<SphereCollider>().enabled = true;
            planetAttached.GetComponent<PlanetMaterialBehaviour>().ChangeMaterialsRenderingMode(PlanetMaterialBehaviour.BlendMode.Opaque);
            planetAttached = null;

        }
    }
}
