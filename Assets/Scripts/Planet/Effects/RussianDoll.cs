using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RussianDoll : MonoBehaviour
{


    public float nbHitNeeded = 2;

    private Vector3 size;
    private float nbHit;

    // Start is called before the first frame update
    void Start()
    {
        nbHit = 0;
        size = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSizeOrDestroy()
    {
        nbHit++;
        //We divide the size of the planet by 2 whenit's touched
        if (nbHit < nbHitNeeded)
        {
            float sizeModifier = (float) ((nbHitNeeded - nbHit) / nbHitNeeded);
            gameObject.transform.localScale = new Vector3(size.x*sizeModifier,size.y*sizeModifier,size.z*sizeModifier);
        } else
        {
            Destroy(gameObject);
        }
    }

}
