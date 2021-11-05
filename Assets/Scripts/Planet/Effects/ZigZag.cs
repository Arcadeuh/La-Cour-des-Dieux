using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZag : MonoBehaviour
{
    public float zigZagRange = 3;
    public float zigZagSpeed = 2f;
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
        //We choose if we go down or up on the z axis
        if (transform.position.z > centerLine + zigZagRange)
        {
            zigZagValue = -1;
        } else if (transform.position.z < centerLine - zigZagRange)
        {
            zigZagValue = 1;
        }
        //We move the planet up or down multiplied by the speed of the zigzag wantend (divided by 100 to reduce effect speed and help user interface)
        transform.position += new Vector3(0, 0, zigZagValue * zigZagSpeed/100);

    }

}
