using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Mis sur une planete
/// gere la collision entre la planete est d'autre objet
/// le joueur
/// des elements du decors
/// </summary>

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");

        TopDownShooter player = collision.gameObject.GetComponentInParent<TopDownShooter>();

        if (player)
        {
            Destroy(player.gameObject);
        }
        Destroy(gameObject);
    }
}
