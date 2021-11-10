using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Mise en place de la scene de fight, 
 * recupere les deck sauvegardes,
 * et met a jour les deck manager.
 * En gros, fait l'interface entre la sauvegarde et le debut du combat
 */
public class LoadManager : MonoBehaviour
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
        //Check si il y a bien une save
        SaveData data = SaveSystem.LoadData();
        if (data == null) { Debug.LogError("No data loaded"); return; }

        //Load la premiere save
        List<Planet> planetsLoaded = new List<Planet>();
        List<string> planetsTitle = data.deckPlayer1.GetListPlanetTitle();
        for(int i=0; i< planetsTitle.Count; i++)
        {
            //Va sauvegarder dans "planetsLoaded" les planetes de "planetsAvailable" ayant les memes noms ("title")
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
        //deckManagerP1.PrintDeckInit(); //DEBUG

        //Load la premiere save
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
        //deckManagerP2.PrintDeckInit(); //DEBUG
    }
}
