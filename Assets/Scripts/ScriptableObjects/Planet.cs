using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlanet", menuName = "Planet")]
public class Planet : ScriptableObject
{
    public string title; // Nom de la planète
    public float radius = 10.0f; // Taille de base
    public float speed = 10.0f; // Vitesse de base
    public Effect active; // Effet associé comme étant actif
    public Effect passive; // Effet associé comme étant passif
    public GameObject appearance; // Apparence
    
}

