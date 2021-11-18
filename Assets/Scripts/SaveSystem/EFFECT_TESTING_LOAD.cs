using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EFFECT_TESTING_LOAD : MonoBehaviour
{
    [SerializeField] private DeckManager deckManagerP1;
    [SerializeField] private DeckManager deckManagerP2;
    [SerializeField] private List<Planet> planetsAvailable;

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
        deckManagerP1.SetDeckInit(planetsAvailable);
        deckManagerP2.SetDeckInit(planetsAvailable);
    }
}
