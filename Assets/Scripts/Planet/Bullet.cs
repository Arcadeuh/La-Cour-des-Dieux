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

    private AudioManager audioManager;

    private void Start()
    {
        UIRounds = GameObject.Find("Rounds").GetComponent<ScoreProgress>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        Debug.Log(audioManager);
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
            //We need this check to avoid the water planet being destroyed on player contact
            if (GetComponent<Water>())
               GetComponent<Water>().RemovePlanet();
            else
               Destroy(gameObject);

            //If the player is shielded
            if (player.shielded && player.shields.Count != 0)
            {

                Destroy(player.shields[0]);
                player.shields.RemoveAt(0);

                flag = false;

                if (player.shields.Count == 0)
                    player.shielded = false;

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

    private void OnDestroy()
    {
        if (audioManager)
        {
            audioManager.Play("DestroyPlanet");
        }
    }

    IEnumerator InvincibleTime()
    {
        yield return new WaitForSeconds(2.0f);
        flag = true;
    }
}
