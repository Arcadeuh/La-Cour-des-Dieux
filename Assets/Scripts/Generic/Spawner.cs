using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private bool spawnOnStart = false;
    // Start is called before the first frame update
    void Start()
    {
        if (spawnOnStart) { SpawnObject(); }
    }

    public void SpawnObject()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }

    public void SetObjectToSpawn(GameObject gameObject)
    {
        objectToSpawn = gameObject;
    }
}
