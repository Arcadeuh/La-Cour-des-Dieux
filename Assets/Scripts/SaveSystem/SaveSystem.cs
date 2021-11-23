using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.InputSystem;

/*
 * Classe static qui gère la sauvegarde et le chargement des données de la partie
 */
public static class SaveSystem
{
    public static Gamepad p1GamePad;
    public static Gamepad p2GamePad;

    public static void SaveDeckData(Deck deckP1, Deck deckP2)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/deckPlayers.god";
        FileStream stream = new FileStream(path, FileMode.Create);

        DeckData listDeckData = new DeckData(deckP1, deckP2);
        formatter.Serialize(stream, listDeckData);
        stream.Close();
    }

    public static void SaveControllerData(Gamepad controllerP1, Gamepad controllerP2)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/controllerPlayers.god";
        FileStream stream = new FileStream(path, FileMode.Create);

        ControllerData controllerData = new ControllerData(controllerP1.name, controllerP2.name);

        p1GamePad = controllerP1;
        p2GamePad = controllerP2;

        formatter.Serialize(stream, controllerData);
        stream.Close();
    }
    public static void SaveRoundsData(int victoryCountP1, int victoryCountP2)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/rounds.god";
        FileStream stream = new FileStream(path, FileMode.Create);

        RoundsData roundData = new RoundsData(victoryCountP1, victoryCountP2);
        formatter.Serialize(stream, roundData);
        stream.Close();
    }

    public static DeckData LoadData()
    {
        string path = Application.persistentDataPath + "/deckPlayers.god";
        if (!File.Exists(path))
        {
            Debug.LogError("Save not found in " + path);
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        DeckData data = formatter.Deserialize(stream) as DeckData;
        return data;
    }

    public static ControllerData LoadControllerData()
    {
        string path = Application.persistentDataPath + "/controllerPlayers.god";
        if (!File.Exists(path))
        {
            Debug.LogError("Save not found in " + path);
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        ControllerData data = formatter.Deserialize(stream) as ControllerData;
        return data;
    }
    public static RoundsData LoadRoundsData()
    {
        string path = Application.persistentDataPath + "/rounds.god";
        if (!File.Exists(path))
        {
            Debug.LogError("Save not found in " + path);
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        RoundsData data = formatter.Deserialize(stream) as RoundsData;
        return data;
    }

}
