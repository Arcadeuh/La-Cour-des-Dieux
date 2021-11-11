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
    [SerializeField] private DeckManager deckManagerP1;
    [SerializeField] private DeckManager deckManagerP2;
    private void Start()
    {
        //Set les deck manager...
        SetEachDeckManager();
        //Et les met a jour
        deckManagerP1.RefillQueueAndHand();
        deckManagerP2.RefillQueueAndHand();
    }

    private void SetEachDeckManager()
    {
        deckManagerP1.SetDeckInit(GetListPlanet(1));
        deckManagerP2.SetDeckInit(GetListPlanet(2));
    }
}
