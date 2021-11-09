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
    private bool flag = true;
    private ScoreProgress UIRounds;

    private void Start()
    {
        UIRounds = GameObject.Find("Rounds").GetComponent<ScoreProgress>();
    }

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
        Debug.Log("Colliding with : " + collision.gameObject.name);

        TopDownShooter player = collision.gameObject.GetComponentInParent<TopDownShooter>();

        if (player && !isDefense && flag)
        {
            //UIRounds.killPlayer(player.name);
            Destroy(player.gameObject);
            Destroy(gameObject);
            UIRounds.killPlayer(player.name);
            flag = false;

        }
        else if (player && isDefense){

        }else
        {

            Destroy(gameObject);
        }
    }
}
