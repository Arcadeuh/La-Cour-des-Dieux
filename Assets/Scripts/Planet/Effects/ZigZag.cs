using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZag : MonoBehaviour
{
    public float zigZagRange = 3;
    public float zigZagSpeed = 2f;
    private float centerLine;
    private float zigZagValue = 2;

    private Rigidbody rb;

    public float frequency = 10.0f; // Speed of sine movement
    public float magnitude = 3f; //  Size of sine movement, its the amplitude of the side curve
    public float speed = 2f;

    private AnimationClip zigZagClip;

    Vector3 pos;
    Vector3 forwardAxis;
    Vector3 vec3zigzagAxis;
    Vector3 tempRotated;

    // Start is called before the first frame update
    void Start()
    {


        rb = GetComponent<Rigidbody>();

        /* zigZagClip = Resources.Load<AnimationClip>("Animations/zigzag");
         Animation zigZagAnim = gameObject.AddComponent<Animation>();
         zigZagAnim.playAutomatically = true;
         zigZagAnim.animatePhysics = true;
         zigZagAnim.cullingType = AnimationCullingType.AlwaysAnimate;


         // create a curve to move the GameObject and assign to the clip
         Keyframe[] keys;
         keys = new Keyframe[3];
         keys[0] = new Keyframe(0.0f, 0.0f);
         // within 12 seconds rotate to 120°
         keys[1] = new Keyframe(1.0f, 1.0f);
         // Whatever you need as 3. keyframe
         keys[2] = new Keyframe(2.0f, 0.0f);

         var curve = new AnimationCurve(keys);
         zigZagClip.SetCurve("", typeof(Transform), "localPosition.z", curve);


         zigZagAnim.clip = zigZagClip;
         zigZagAnim.AddClip(zigZagClip, "zigzag");
         zigZagAnim.Play();

         */

        //forwardAxis = transform.forward;

        // Initialization for zigzag parameters
        forwardAxis = transform.forward;
        pos = transform.position;


        Vector3 temp = forwardAxis.normalized;
        tempRotated = Quaternion.AngleAxis(-90, Vector3.up) * temp;

        float force = 0;
        force = (zigZagRange + Time.deltaTime) % zigZagRange - zigZagRange / 2;

        Vector3 newVector = tempRotated * force;

        /*Vector2 vec2ZigZagAxis = new Vector2(forwardAxis.x, forwardAxis.z);
        vec3zigzagAxis = new Vector3(Vector2.Perpendicular(vec2ZigZagAxis).x, 0, Vector2.Perpendicular(vec2ZigZagAxis).y);*/
    }

    // Update is called once per frame
    void Update()
    {

        //pos += tempRotated * Time.deltaTime * speed;
        rb.AddForce(tempRotated * Mathf.Sin(Time.time * frequency) * magnitude, ForceMode.Acceleration);
        //rb.AddForce(newVector);

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


         /*Vector2 vec2ZigZagAxis = new Vector2(forwardAxis.x, forwardAxis.z);
         Vector3 vec3zigzagAxis = new Vector3(Vector2.Perpendicular(vec2ZigZagAxis).x,0, Vector2.Perpendicular(vec2ZigZagAxis).y);


         transform.position += (vec3zigzagAxis * Mathf.Sin(Time.time * frequency) * magnitude ) * speed;
         */
    }

}
