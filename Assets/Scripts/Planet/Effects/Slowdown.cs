using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdown : MonoBehaviour
{

    private float areaOfEffectRadius = 3;
    private float slowIntensity = 30;

    private GameObject effectArea;

    // Start is called before the first frame update
    void Start()
    {
        //We create the area of effect game object
        effectArea = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        effectArea.transform.parent = transform;
        effectArea.transform.localScale = new Vector3(areaOfEffectRadius * 2, areaOfEffectRadius * 2, areaOfEffectRadius * 2);
        effectArea.transform.localPosition = new Vector3(0, 0, 0);

        effectArea.GetComponent<SphereCollider>().radius = 0.5f;
        effectArea.GetComponent<SphereCollider>().isTrigger = true;

        Material material = Resources.Load<Material>("Materials/SlowDownAreaMaterial");

        effectArea.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        effectArea.GetComponent<MeshRenderer>().material = material;


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
