using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    [SerializeField] private DisplayDeck displayDeckP1;
    [SerializeField] private DisplayDeck displayDeckP2;
    private Deck deckP1;
    private Deck deckP2;

    public void SetAndSaveDecks()
    {
        deckP1 = new Deck(1, displayDeckP1.GetPlanetsToShow());
        deckP2 = new Deck(2, displayDeckP2.GetPlanetsToShow());
        SaveSystem.SaveDeck(deckP1, deckP2);
    }

    public void LoadDecksSaved()
    {
        ListDeckData data = SaveSystem.LoadListDeck();
        if (data == null) { Debug.LogError("Load failed"); return; }
        foreach(string title in data.deckPlayer1.GetListPlanetTitle())
        {
            Debug.Log(title);
        }
        foreach (string title in data.deckPlayer2.GetListPlanetTitle())
        {
            Debug.Log(title);
        }
    }
}
