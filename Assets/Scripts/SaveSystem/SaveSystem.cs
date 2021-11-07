using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    
    public static void SaveDeck(Deck deckP1, Deck deckP2)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/deckPlayers.god";
        FileStream stream = new FileStream(path, FileMode.Create);

        ListDeckData listDeckData = new ListDeckData(deckP1, deckP2);
        formatter.Serialize(stream, listDeckData);
        stream.Close();
    }

    public static ListDeckData LoadListDeck()
    {
        string path = Application.persistentDataPath + "/deckPlayers.god";
        if (!File.Exists(path))
        {
            Debug.LogError("Save not found in " + path);
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);
        ListDeckData data = formatter.Deserialize(stream) as ListDeckData;
        return data;
    }

}
