using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    private List<Planet> listPlanet;

    Deck()
    {
        listPlanet = new List<Planet>();
    }

    public void SetDeck(List<Planet> planets)
    {
        Planet[] tempListPlanet = new Planet[planets.Count];
        listPlanet = new List<Planet>(tempListPlanet);
    }

    public void AddPlanetToDeck(Planet planet)
    {
        listPlanet.Add(planet);
    }
}
