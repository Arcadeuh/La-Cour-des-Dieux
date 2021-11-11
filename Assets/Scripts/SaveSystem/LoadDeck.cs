using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class which get decks
 */
public class LoadDeck : MonoBehaviour
{
    [SerializeField] private List<Planet> planetsAvailable;
    private SaveData saveData;

    private void Awake()
    {
        saveData = SaveSystem.LoadData();
    }

    public List<Planet> GetListPlanet(int player)
    {
        if (saveData == null) { Debug.LogError("No data loaded"); return null; }

        Deck deck = null;
        if (player == 1) { deck = saveData.deckPlayer1; }
        else if (player == 2){ deck = saveData.deckPlayer2; }
        else { 
            Debug.LogError("int player should be 1 or 2"); 
            return null; 
        }

        List<Planet> planetsLoaded = new List<Planet>();
        List<string> planetsTitle = deck.GetListPlanetTitle();
        for (int i = 0; i < planetsTitle.Count; i++)
        {
            Planet[] tempListPlanet = new Planet[planetsAvailable.Count];
            planetsAvailable.CopyTo(tempListPlanet);
            for (int j = 0; j < tempListPlanet.Length; j++)
            {
                if (planetsTitle[i] == tempListPlanet[j].title)
                {
                    planetsLoaded.Add(tempListPlanet[j]);
                    break;
                }
            }
        }
        return planetsLoaded;
    }
}
