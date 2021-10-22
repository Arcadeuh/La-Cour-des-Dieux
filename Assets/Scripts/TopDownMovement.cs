/*
 * Component à ajouter à un objet que l'on souhaite deplacer à l'aide d'input
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0.0f, vertical).normalized;

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, targetAngle, 0.0f);

            controller.Move(direction * speed * Time.deltaTime);
        }

    }
}
