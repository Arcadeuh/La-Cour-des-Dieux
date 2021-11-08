using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMesh3d : MonoBehaviour
{

    public GameObject dummies;
    public GameObject[] planetesMeshes; 
    // Start is called before the first frame update
    void Start()
    {
       definePlanetStyle(); 
       
    }

    public void definePlanetStyle(){
        Debug.Log("Set planet visu");
        dummies.GetComponent<MeshRenderer>().enabled = false;


        foreach(GameObject planet in planetesMeshes){
            planet.SetActive(false);
        }

        int i = Random.Range(0,planetesMeshes.Length);
        planetesMeshes[i].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
