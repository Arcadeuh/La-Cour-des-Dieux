using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private GameObject playerShielded;
    private GameObject shield = null;

    // Start is called before the first frame update
    void Start()
    {
        //We get the player who placed the planet
        playerShielded = GameObject.Find(tag.Substring(0,7));

        if (!playerShielded.GetComponent<TopDownShooter>().shielded)
        {
            //We create the area of effect game object
            shield = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            shield.transform.parent = playerShielded.transform;
            shield.transform.localScale = new Vector3(2, 2, 2);
            shield.transform.localPosition = new Vector3(0, 0, 0);

            Material material = Resources.Load<Material>("Materials/ShieldMaterial");

            shield.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

            shield.GetComponent<MeshRenderer>().material = material;

            playerShielded.GetComponent<TopDownShooter>().shielded = true;
            playerShielded.GetComponent<TopDownShooter>().shield = shield;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!playerShielded.GetComponent<TopDownShooter>().shielded && shield)
        {
            Destroy(shield);
        }
    }
}
