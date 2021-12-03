using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LoadDeckBuilding : LoadDeck
{
    [SerializeField] private DisplayDeck deckP1;
    [SerializeField] private DisplayDeck deckP2;

    // Start is called before the first frame update
    private void Start()
    {
        deckP1.SetPlanetsToShow(GetListPlanet(1));
        deckP2.SetPlanetsToShow(GetListPlanet(2));
        deckP1.DisplayPlanets();
        deckP2.DisplayPlanets();
    }
}
