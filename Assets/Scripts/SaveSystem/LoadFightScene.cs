using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Mise en place de la scene de fight, 
 * recupere les deck sauvegardes,
 * et met a jour les deck manager.
 * En gros, fait l'interface entre la sauvegarde et le debut du combat
 */
public class LoadFightScene : LoadDeck
{
    public bool testMode = false;
    private void Start()
    {
        if (testMode)
        {
            DeckManager deckManagerP1 = GameObject.Find("Player1").GetComponent<DeckManager>();
            DeckManager deckManagerP2 = GameObject.Find("Player2").GetComponent<DeckManager>();

            deckManagerP1.RefillQueueAndHand();
            deckManagerP2.RefillQueueAndHand();
        }
        else
        {
            Debug.Log("ONE");
            DeckManager deckManagerP1 = GameObject.Find("Player1").GetComponent<DeckManager>();
            DeckManager deckManagerP2 = GameObject.Find("Player2").GetComponent<DeckManager>();
            Debug.Log(deckManagerP1);
            Debug.Log(deckManagerP2);

            //Set les deck manager...
            deckManagerP1.SetDeckInit(GetListPlanet(1));
            deckManagerP2.SetDeckInit(GetListPlanet(2));
            Debug.Log("THREE");
            //Et les met a jour
            deckManagerP1.RefillQueueAndHand();
            deckManagerP2.RefillQueueAndHand();
            Debug.Log("FOUR");
        }
    }
}
