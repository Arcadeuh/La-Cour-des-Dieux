using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Permet la sélection de planètes de manière random
 */
public class SelectPlanetsRandom : MonoBehaviour
{

    public List<Planet> listPlanets = new List<Planet>();
    [SerializeField] private int numberPlanetsToGet = 4;
    [Header("Display features")]
    public bool showAtStart = false;
    [SerializeField] private DisplayDeck displayDeck;

    private List<Planet> planetsSelected = new List<Planet>();

    // Start is called before the first frame update
    void Start()
    {
        //If "showAtStart", show them using DisplayDeck script
        SelectPlanets(numberPlanetsToGet);
        if (showAtStart)
        {
            if (!displayDeck) { 
                Debug.LogError("No DisplayDeck set"); 
                return; 
            }
            displayDeck.SetPlanetsToShow(GetPlanetsSelected());
            displayDeck.DisplayPlanets();
        }
    }

    public List<Planet> GetPlanetsSelected()
    {
        Planet[] tempListPlanet = new Planet[planetsSelected.Count];
        planetsSelected.CopyTo(tempListPlanet);
        return new List<Planet>(tempListPlanet);
    }

    public void SelectPlanets(int numberPlanets)
    {
        //Need a list of planet to pick inside
        if (listPlanets.Count == 0)
        {
            Debug.LogError("No planet provided in 'listPlanets'");
            return;
        }

        //Make a copy of "numberPlanets" random planets from listPlanets
        Planet[] tempListPlanet = new Planet[listPlanets.Count];
        listPlanets.CopyTo(tempListPlanet);
        planetsSelected = new List<Planet>();
        for (int i = 0; i < numberPlanets; i++)
        {
            int index = Random.Range(0, tempListPlanet.Length);

            if (planetsSelected.Contains(tempListPlanet[index]))//if planet is already selected, do another loop
            {
                i--;
                continue;
            }
            planetsSelected.Add(tempListPlanet[index]);
        }
    }
}