using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdown : MonoBehaviour
{

    private float areaOfEffectRadius = 3;
    private float slowIntensity = 30;

    // Start is called before the first frame update
    void Start()
    {
        SphereCollider sc = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
        sc.radius = areaOfEffectRadius;
        sc.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 7 && other.tag != gameObject.tag)
        {
            Vector3 slowingVector = other.GetComponent<Rigidbody>().velocity * -1;
            other.GetComponent<Rigidbody>().AddForce(slowingVector * other.GetComponent<Bullet>().bulletForce/ slowIntensity, ForceMode.Impulse);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 7 && other.tag != gameObject.tag)
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Rigidbody>().AddForce(other.GetComponent<Bullet>().forwardVector * other.GetComponent<Bullet>().bulletForce, ForceMode.Impulse);
        }
    }
}
