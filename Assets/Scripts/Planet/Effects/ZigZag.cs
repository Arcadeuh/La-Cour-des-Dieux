using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZag : MonoBehaviour
{

    private bool notSet = true;

    private float offset = Mathf.PI/2;

    private Rigidbody rb;

    public float frequency; // Speed of sine movement
    public float magnitude; //  Size of sine movement, its the amplitude of the side curve
    public float speed; // the offset speed

    private Vector3 tempRotated;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        frequency = GetComponent<Bullet>().bulletForce/50;
        magnitude = GetComponent<Bullet>().bulletForce/50;
        speed = GetComponent<Bullet>().bulletForce/50;
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void FixedUpdate()
    {
        if (rb.velocity != Vector3.zero)
        {
            if (notSet)
            {
                notSet = false;
                tempRotated = (Quaternion.AngleAxis(-90, Vector3.up) * rb.velocity.normalized);
            } else
            {
                offset += speed;
                Vector3 position = tempRotated * Mathf.Sin(offset * frequency) * magnitude;
                transform.localPosition += position;
            }

        }
    }

}
