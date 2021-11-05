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
        initialAngularDrag = rb.angularDrag;
        rb.angularDrag = 0;
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.material = Resources.Load<PhysicMaterial>("Materials/BouncingMaterial");
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void Deactivate()
    {
        bounceActivated = false;
        rb.angularDrag = initialAngularDrag;
        sphereCollider.material = null;
    }

    public bool GetBounceActivated()
    {
        return bounceActivated;
    }
}
