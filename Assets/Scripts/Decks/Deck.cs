using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deck
{
    private List<string> listPlanet;
    private int idPlayer;
    //[SerializeField] private static List<Planet> planetsAvailable;

    public Deck(int idPlayer)
    {
        listPlanet = new List<string>();
        this.idPlayer = idPlayer;
    }

    public Deck(int idPlayer, List<Planet> listPlanets)
    {
        SetDeck(listPlanets);
        this.idPlayer = idPlayer;
    }

    public void SetDeck(List<Planet> planets)
    {
        listPlanet = new List<string>();
        foreach(Planet planet in planets)
        {
            listPlanet.Add(planet.title);
        }
    }

    public void AddPlanetToDeck(Planet planet)
    {
        listPlanet.Add(planet.title);
    }

    public int GetIdPlayer()
    {
        return idPlayer;
    }

    public List<string> GetListPlanetTitle()
    {
        return listPlanet;
    }

    /*
    public List<Planet> GetListPlanet()
    {
        List<Planet> planetsDeck = new List<Planet>();
        foreach(string planetTitle in listPlanet)
        {
            for(int i=0; i<planetsAvailable.Count; i++)
            {
                if(planetTitle == planetsAvailable[i].title)
                {
                    planetsDeck.Add()
                }
            }
        }
    }
    */
}
