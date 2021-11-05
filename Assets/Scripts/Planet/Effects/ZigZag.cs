using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZag : MonoBehaviour
{
    public float zigZagRange = 15;
    public float zigZagSpeed = 0.1f;
    private float centerLine;
    private float zigZagValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        centerLine = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.z > centerLine + zigZagRange)
        {
            zigZagValue = -1;
        } else if (transform.position.z < centerLine - zigZagRange)
        {
            zigZagValue = 1;
        }
        GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, zigZagValue * zigZagSpeed),ForceMode.VelocityChange);
        //transform.position += new Vector3(0,0, zigZagValue * zigZagSpeed);
        //transform.position = new Vector3(transform.position.x, transform.position.y, pingPong);

    }

}
