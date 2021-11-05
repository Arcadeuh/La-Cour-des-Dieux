using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{

    private Rigidbody rb;
    private SphereCollider sphereCollider;
    private float initialAngularDrag;
    private bool bounceActivated;

    // Start is called before the first frame update
    void Start()
     {
        bounceActivated = true;
        rb = GetComponent<Rigidbody>();
        //We store the inital angular drag for future reuse
        initialAngularDrag = rb.angularDrag;
        //We set the rigidbody angular drag to 0
        rb.angularDrag = 0;
        sphereCollider = GetComponent<SphereCollider>();
        //We use the bouncing physic material as new sphere colider physic material
        sphereCollider.material = Resources.Load<PhysicMaterial>("Materials/BouncingMaterial");
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    //We disbale the bouncing effect
    public void Deactivate()
    {
        //We activate the future collisions
        bounceActivated = false;
        //We restore the rigidbody to it's normal state
        rb.angularDrag = initialAngularDrag;
        //We remove the bouncing physic material
        sphereCollider.material = null;
    }

    public bool GetBounceActivated()
    {
        return bounceActivated;
    }
}
