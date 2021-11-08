using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZag : MonoBehaviour
{
    public float zigZagRange = 3;
    public float zigZagSpeed = 2f;
    private float centerLine;
    private float zigZagValue = 1;


    public float frequency = 3f; // Speed of sine movement
    public float magnitude = 1f; //  Size of sine movement, its the amplitude of the side curve
    public float speed = 0.1f;

    private AnimationClip zigZagClip;

    Vector3 pos;
    Vector3 forwardAxis;

    // Start is called before the first frame update
    void Start()
    {
        zigZagClip = Resources.Load<AnimationClip>("Animations/zigzag");
        Animation zigZagAnim = gameObject.AddComponent<Animation>();
        zigZagAnim.playAutomatically = true;
        zigZagAnim.animatePhysics = true;
        zigZagAnim.cullingType = AnimationCullingType.AlwaysAnimate;
        zigZagAnim.clip = zigZagClip;
        zigZagAnim.AddClip(zigZagClip, "zigzag");
        zigZagAnim.Play();

        //forwardAxis = transform.forward;

        // Initialization for zigzag parameters
        forwardAxis = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        //We choose if we go down or up on the z axis
        /*if (transform.localPosition.z > centerLine + zigZagRange)
        {
            zigZagValue = -1;
        } else if (transform.localPosition.z < centerLine - zigZagRange)
        {
            zigZagValue = 1;
        }
        //We move the planet up or down multiplied by the speed of the zigzag wantend (divided by 100 to reduce effect speed and help user interface)
        transform.localPosition += new Vector3(zigZagValue * zigZagSpeed / 100, 0, 0);
        */

        //pos += Vector3.down * Time.deltaTime * speed;


       /* Vector2 vec2ZigZagAxis = new Vector2(forwardAxis.x, forwardAxis.z);
        Vector3 vec3zigzagAxis = new Vector3(Vector2.Perpendicular(vec2ZigZagAxis).x,0, Vector2.Perpendicular(vec2ZigZagAxis).y);


        transform.position += (vec3zigzagAxis * Mathf.Sin(Time.time * frequency) * magnitude ) * speed;
        */
    }

}
