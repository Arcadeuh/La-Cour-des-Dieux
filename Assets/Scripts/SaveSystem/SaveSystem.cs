using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.InputSystem;

/*
 * Classe static qui gère la sauvegarde et le chargement des données de la partie
 */
public static class SaveSystem
{
    
    public static void SaveDeckData(Deck deckP1, Deck deckP2)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/deckPlayers.god";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData listDeckData = new SaveData(deckP1, deckP2);
        formatter.Serialize(stream, listDeckData);
        stream.Close();
    }

    public static void SaveControllerData(string controllerP1, string controllerP2)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/controllerPlayers.god";
        FileStream stream = new FileStream(path, FileMode.Create);

        ControllerData controllerData = new ControllerData(controllerP1, controllerP2);
        formatter.Serialize(stream, controllerData);
        stream.Close();
    }

    public static SaveData LoadData()
    {
        string path = Application.persistentDataPath + "/deckPlayers.god";
        if (!File.Exists(path))
        {
            Debug.LogError("Save not found in " + path);
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        SaveData data = formatter.Deserialize(stream) as SaveData;
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

}
