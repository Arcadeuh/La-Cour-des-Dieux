using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Permit to show a deck save in this script
 */
public class DisplayDeck : MonoBehaviour
{
    private List<Planet> planetsToShow;
    [SerializeField] private List<GameObject> cards;

    private void Start()
    {
        //FOR TEST PURPOSE ONLY
        //DisplayPlanets();
    }

    public void DisplayPlanets()
    {
        //Reject the case where there is not enough cards to show the whole deck
        if(cards.Count < planetsToShow.Count) { 
            Debug.LogError("Not enough cards.\nMake a shorter list of planets, or add more cards."); 
            return; 
        }
        for(int i = 0; i< cards.Count; i++)
        {
            //if there is too much card, disable them
            if (i >= planetsToShow.Count) {
                cards[i].SetActive(false);
                continue;
            }

            DisplayCard card = cards[i].GetComponent<DisplayCard>();
            card.SetPlanet(planetsToShow[i]);
            card.Display();
        }
    }

    public void SetPlanetsToShow(List<Planet> planets)
    {
        Planet[] tempListPlanet = new Planet[planets.Count];
        planets.CopyTo(tempListPlanet);
        planetsToShow = new List<Planet>(tempListPlanet);
    }

    public List<Planet> GetPlanetsToShow()
    {
        Planet[] tempListPlanet = new Planet[planetsToShow.Count];
        planetsToShow.CopyTo(tempListPlanet);
        return new List<Planet>(tempListPlanet);
    }
}
