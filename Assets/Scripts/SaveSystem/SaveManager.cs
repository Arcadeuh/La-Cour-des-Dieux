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

    public void SetAndSaveDecks()
    {
        deckP1 = new Deck(1, displayDeckP1.GetPlanetsToShow());
        deckP2 = new Deck(2, displayDeckP2.GetPlanetsToShow());
        SaveSystem.SaveData(deckP1, deckP2);
    }

    //JUSTE FOR TEST, TO SEE IF IT'S SAVED OR NOT
    public void LoadDecksSaved()
    {
        SaveData data = SaveSystem.LoadData();
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
