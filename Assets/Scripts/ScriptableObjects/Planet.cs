using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlanet", menuName = "Planet")]
public class Planet : ScriptableObject
{
    public string title;
    public float radius = 10.0f;
    public float speed = 10.0f;
    public Effect active;
    public Effect passive;
    public GameObject appearance;

}
