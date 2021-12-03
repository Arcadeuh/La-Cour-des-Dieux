/*
 * Objet contenant ce qui doit être sauvegarder
 */
[System.Serializable]
public class DeckData
{
    public Deck deckPlayer1;
    public Deck deckPlayer2;

    public DeckData(Deck p1, Deck p2)
    {
        deckPlayer1 = p1;
        deckPlayer2 = p2;
    }
}

[System.Serializable]
public class ControllerData
{
    public string controllerP1;
    public string controllerP2;

    public ControllerData(string p1, string p2)
    {
        controllerP1 = p1;
        controllerP2 = p2;
    }
}

[System.Serializable]
public class RoundsData
{
    public int victoryCountP1;
    public int victoryCountP2;

    public RoundsData(int p1, int p2)
    {
        victoryCountP1 = p1;
        victoryCountP2 = p2;
    }
}
