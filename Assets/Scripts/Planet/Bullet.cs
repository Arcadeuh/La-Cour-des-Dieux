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
    private bool explosionPossible = true;
    private ScoreProgress UIRounds;
    private ParticleSystem explosion;
    private ParticleSystem fumee;

    private AudioManager audioManager;

    private void Start()
    {
        UIRounds = GameObject.Find("Rounds").GetComponent<ScoreProgress>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        explosion = GameObject.Find("ParticuleExplosion").GetComponent<ParticleSystem>();
        fumee = GameObject.Find("ParticuleFumee").GetComponent<ParticleSystem>();
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
        Debug.Log("Colliding with : " + collision.gameObject.name);

        //Get TopDownShooter from the object (can be null, we'll use this case next)
        TopDownShooter player = collision.gameObject.GetComponentInParent<TopDownShooter>();

        //Set position for explosion effects
        explosion.transform.position = gameObject.transform.position;
        fumee.transform.position = gameObject.transform.position;

        //if there is a TopDownShooter (trad: if it's a player), the bullet is attacking (do it once)
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
                UnityEngine.InputSystem.Gamepad playerGamepad;
                if (player.gameObject.name == "Player1")
                    playerGamepad = SaveSystem.p1GamePad;
                else
                    playerGamepad = SaveSystem.p2GamePad;
                if (playerGamepad!=null){ UIRounds.StartCoroutine(UIRounds.InvincibleTimeAndRumble(playerGamepad)); }
                UIRounds.killPlayer(player.name);
                flag = false;
                StartCoroutine("InvincibleTime");
            }

            //UIRounds.killPlayer(player.name);
            //Destroy(player.gameObject);
            Destroy(gameObject);
            if (explosionPossible)
            {
                explosion.Play();
                fumee.Play();
                explosionPossible = false;
            }
        }
        else if (player && isDefense){

        }else //if this is not a player
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
                    
                    if (explosionPossible)
                    {
                        explosion.Play();
                        
                        fumee.Play();
                        explosionPossible = false;
                    }
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
            if (explosionPossible)
            {
                explosion.Play();
                fumee.Play();
                explosionPossible = false;
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
