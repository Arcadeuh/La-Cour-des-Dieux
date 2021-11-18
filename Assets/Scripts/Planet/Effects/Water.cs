using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    GameObject particleTrail;

    // Start is called before the first frame update
    void Start()
    {
        particleTrail = (GameObject)Instantiate(Resources.Load("Prefabs/Effects/ParticleTrail"), transform);
    }


    public void RemovePlanet()
    {
        //On détruit tous les composants de mouvements.affichage/collisions de la planète pour la faire "disparaître" mais garder la trail ralentissante
        Destroy(GetComponent<MeshRenderer>());
        Destroy(GetComponent<MeshFilter>());
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<SphereCollider>());
        StartCoroutine(particleTrail.GetComponent<WaterTrailBehaviour>().waitBeforeDestroy());
    }


}
