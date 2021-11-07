using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ListDeckData
{
    public Deck deckPlayer1;
    public Deck deckPlayer2;

    public ListDeckData(Deck p1, Deck p2)
    {
        deckPlayer1 = p1;
        deckPlayer2 = p2;
    }
}
