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
        //On d�truit tous les composants de mouvements.affichage/collisions de la plan�te pour la faire "dispara�tre" mais garder la trail ralentissante
        Destroy(GetComponent<MeshRenderer>());
        Destroy(GetComponent<MeshFilter>());
        Destroy(GetComponent<Rigidbody>());
        Destroy(GetComponent<SphereCollider>());
        StartCoroutine(particleTrail.GetComponent<WaterTrailBehaviour>().waitBeforeDestroy());
    }


}
