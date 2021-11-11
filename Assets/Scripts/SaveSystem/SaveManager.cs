using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Interface entre les decks affichés (DisplayDeck),
 * les cartes sélectionnés (ENCORE A FAIRE)
 * et le système de sauvegarde (SaveSystem)
 */
public class SaveManager : MonoBehaviour
{
    [SerializeField] private DisplayDeck displayDeckP1;
    [SerializeField] private DisplayDeck displayDeckP2;
    private Deck deckP1;
    private Deck deckP2;

    public string tagTokensP1 = "TokenP1";
    public string tagTokensP2 = "TokenP2";

    public void SetAndSaveDecks()
    {
        if (displayDeckP1 == null)
        {
            deckP1 = new Deck(1);
            deckP2 = new Deck(2);
        }
        else
        {
            deckP1 = new Deck(1, displayDeckP1.GetPlanetsToShow());
            deckP2 = new Deck(2, displayDeckP2.GetPlanetsToShow());
        }

        GameObject[] tokensP1 = GameObject.FindGameObjectsWithTag("TokenP1");
        foreach(GameObject token in tokensP1)
        {
            deckP1.AddPlanetToDeck(token.GetComponentInParent<DisplayCard>().GetPlanet());
        }

        GameObject[] tokensP2 = GameObject.FindGameObjectsWithTag("TokenP2");
        foreach (GameObject token in tokensP2)
        {
            deckP2.AddPlanetToDeck(token.GetComponentInParent<DisplayCard>().GetPlanet());
        }

        SaveSystem.SaveData(deckP1, deckP2);
    }

    //JUSTE FOR TEST, TO SEE IF IT'S SAVED OR NOT
    public void LoadDecksSaved()
    {
        SaveData data = SaveSystem.LoadData();
        if (data == null) { Debug.LogError("Load failed"); return; }
        Debug.Log("PLAYER 1");
        foreach (string title in data.deckPlayer1.GetListPlanetTitle())
        {
            Debug.Log(title);
        }
        Debug.Log("PLAYER 2");
        foreach (string title in data.deckPlayer2.GetListPlanetTitle())
        {
            Debug.Log(title);
        }
    }
}
