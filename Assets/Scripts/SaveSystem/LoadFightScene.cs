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

    private void Start()
    {
        DeckManager deckManagerP1 = GameObject.Find("Player1").GetComponent<DeckManager>();
        DeckManager deckManagerP2 = GameObject.Find("Player2").GetComponent<DeckManager>();

        //Set les deck manager...
        deckManagerP1.SetDeckInit(GetListPlanet(1));
        deckManagerP2.SetDeckInit(GetListPlanet(2));
        //Et les met a jour
        deckManagerP1.RefillQueueAndHand();
        deckManagerP2.RefillQueueAndHand();
    }
}
