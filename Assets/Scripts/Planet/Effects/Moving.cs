using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float movementSpeed = 0.1f;
    public float verticalMoveRange = 3;
    private float initialVerticalValue;
    private float modifier = 1;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None; //We remove the constraints to allow the rigibody to move
        GetComponent<Rigidbody>().isKinematic = true; //We make the planet kinematic to make it not movable by other objects 
        initialVerticalValue = transform.position.z;
    } 

    // Update is called once per frame
    void Update()
    {
        //choosing if we go down or up depending on the initialVerticalValue and the verticalMoveRange
        if (transform.position.z > initialVerticalValue + verticalMoveRange)
            modifier = -1;
        else if (transform.position.z < initialVerticalValue - verticalMoveRange)
            modifier = 1;
    }

    private void FixedUpdate()
    {
        //we move the planet upward or downward depending on the modifier, and the multiply the movement by movementSpeed
        Vector3 newDestination = new Vector3(transform.position.x, transform.position.y, transform.position.z + modifier * movementSpeed);
        GetComponent<Rigidbody>().MovePosition(newDestination);
    }
}
