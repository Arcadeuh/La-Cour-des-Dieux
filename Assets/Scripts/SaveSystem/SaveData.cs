/*
 * Objet contenant ce qui doit être sauvegarder
 */
[System.Serializable]
public class SaveData
{
    public Deck deckPlayer1;
    public Deck deckPlayer2;

    public SaveData(Deck p1, Deck p2)
    {
        deckPlayer1 = p1;
        deckPlayer2 = p2;
    }
}

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
