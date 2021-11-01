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

    private bool isDefense = false;

    // disable collision
    public void setIsDefense(bool newIsDefense) {
        isDefense = newIsDefense;

        if (isDefense)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        TopDownShooter player = collision.gameObject.GetComponentInParent<TopDownShooter>();

        if (player && !isDefense)
        {
            Destroy(player.gameObject);
            Destroy(gameObject);
        }
        else if (player && isDefense){

        }else
        {

            Destroy(gameObject);
        }
    }
}
