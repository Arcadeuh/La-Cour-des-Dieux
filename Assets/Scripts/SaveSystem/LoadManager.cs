using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    [SerializeField] private DeckManager deckManagerP1;
    [SerializeField] private DeckManager deckManagerP2;
    [SerializeField] private List<Planet> planetsAvailable;
    private void Start()
    {
        SetEachDeckManager();
        deckManagerP1.RefillQueueAndHand();
        deckManagerP2.RefillQueueAndHand();
    }

    private void SetEachDeckManager()
    {
        ListDeckData data = SaveSystem.LoadListDeck();
        if (data == null) { Debug.LogError("No data loaded"); return; }

        List<Planet> planetsLoaded = new List<Planet>();
        List<string> planetsTitle = data.deckPlayer1.GetListPlanetTitle();
        for(int i=0; i< planetsTitle.Count; i++)
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
        deckManagerP1.SetDeckInit(planetsLoaded);
        deckManagerP1.PrintDeckInit();

        planetsLoaded = new List<Planet>();
        planetsTitle = data.deckPlayer2.GetListPlanetTitle();
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
        deckManagerP2.SetDeckInit(planetsLoaded);
        deckManagerP2.PrintDeckInit();
    }
}
