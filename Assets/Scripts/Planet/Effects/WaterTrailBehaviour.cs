using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTrailBehaviour : MonoBehaviour
{

    private ParticleSystem ps;

    // these lists are used to contain the particles which match
    // the trigger conditions each frame.
    private readonly List<ParticleSystem.Particle> insidePlayerCollider = new List<ParticleSystem.Particle>();

    private GameObject playerSlowed = null;

    private float initialPlayerSpeed = 12f;

    //We use this variable to handle the conflict when there is 2 or more planet with this effect active at same time
    private bool slowing;

    private float timeBeforeDestroy;


    // Start is called before the first frame update
    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
        timeBeforeDestroy = ps.main.duration;

        GameObject[] players = FindGameObjectsWithLayer(8);
        GameObject player1 = null;
        GameObject player2 = null;
        
        foreach (GameObject player in players)
        {
            if (player.name == "Player1")
                player1 = player;
            else
                player2 = player;
        }
        if (transform.parent.gameObject.tag == "Player1Planets")
        {
            ps.trigger.AddCollider(player2.transform);
            playerSlowed = player2;
        }
        else if (transform.parent.gameObject.tag == "Player2Planets")
        {
            ps.trigger.AddCollider(player1.transform);
            playerSlowed = player1;
        }
        initialPlayerSpeed = playerSlowed.GetComponent<TopDownMovement>().maxSpeed;
        

    }

    private void OnParticleTrigger()
    {

        // get the particles which matched the trigger conditions this frame
        ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, insidePlayerCollider);

        if (playerSlowed)
        {

            if (insidePlayerCollider.Count > 0)
            {
                //We reduce the player speed
                playerSlowed.GetComponent<TopDownMovement>().currentSpeed = initialPlayerSpeed / 3;
                slowing = true;
            }
            else if (insidePlayerCollider.Count == 0 && slowing)
            {
                //We reset the player speed
                playerSlowed.GetComponent<TopDownMovement>().currentSpeed = initialPlayerSpeed;
                slowing = false;
            }

        }

    }


    private GameObject[] FindGameObjectsWithLayer(int layer){
        GameObject[] allGoArray = FindObjectsOfType<GameObject>();
        List<GameObject> layerGoList = new System.Collections.Generic.List<GameObject>();
        for (var i = 0; i< allGoArray.Length; i++) {
            if (allGoArray[i].layer == layer) {
                layerGoList.Add(allGoArray[i]);
            }
        }
        if (layerGoList.Count == 0)
        {
            return null;
        }
        return layerGoList.ToArray();
    }

    //On détruit la planète quand toutes les particules ont disparues
    public IEnumerator waitBeforeDestroy()
    {
        //Wait for the all the particles to disappear
        yield return new WaitForSeconds(timeBeforeDestroy);

        playerSlowed.GetComponent<TopDownMovement>().currentSpeed = playerSlowed.GetComponent<TopDownMovement>().maxSpeed;

        Destroy(transform.parent.gameObject);

    }

}
