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


    public float bulletForce;
    public Vector3 forwardVector;


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
        //Debug.Log("Colliding with : " + collision.gameObject.name);

        TopDownShooter player = collision.gameObject.GetComponentInParent<TopDownShooter>();

        if (player && !isDefense && flag)
        {
            Destroy(gameObject);

            //If the player is shielded
            if (player.shielded && player.shield)
            {
                player.shielded = false;
                flag = false;
                Destroy(player.shield);
            } else
            {
                UIRounds.killPlayer(player.name);
                flag = false;
                StartCoroutine("InvincibleTime");
            }

        }
        else if (player && isDefense){

        }else
        {            
            //We check if a bouncing script is attached to the planet and if yes if the bouncing effect is deactivated
            if (GetComponent<Bounce>())
            {
                //We check if we are not colliding with a planet
                if (collision.gameObject.layer != 7)
                {
                    GetComponent<Bounce>().DeactivateOrDestroy();
                } else
                {
                    Destroy(gameObject);
                }
            }
            //We check if a RussianDoll script is attached to the planet and if yes we reduce the size of the planet or destroy it
            else if (GetComponent<RussianDoll>())
            {
                GetComponent<RussianDoll>().UpdateSizeOrDestroy();
            }
            else if (GetComponent<Water>())
            {
                GetComponent<Water>().RemovePlanet();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    IEnumerator InvincibleTime()
    {
        yield return new WaitForSeconds(2.0f);
        flag = true;
    }
}
