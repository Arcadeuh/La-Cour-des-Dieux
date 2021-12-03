using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{

    private Rigidbody rb;
    private Bullet bulletScript;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bulletScript = GetComponent<Bullet>();
        rb.AddForce(bulletScript.forwardVector * bulletScript.bulletForce/2,ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
