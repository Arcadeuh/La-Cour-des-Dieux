using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.InputSystem;

/*
 * Classe static qui gère la sauvegarde et le chargement des données de la partie
 */
public static class SaveSystem
{
    
    public static void SaveData(Deck deckP1, Deck deckP2)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/deckPlayers.god";
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData listDeckData = new SaveData(deckP1, deckP2);
        formatter.Serialize(stream, listDeckData);
        stream.Close();
    }

    //Well. This is just a test...
    public static void SetPlayersController(PlayerInput playerInput)
    {
        if(playerInput.devices.Count == 0) { Debug.LogError("Not enough controllers detected"); return; }
        InputDevice playerDevice = playerInput.devices[0];
        Gamepad gamepad = (Gamepad)InputSystem.GetDeviceById(playerDevice.deviceId);
        Debug.Log(gamepad.deviceId);
        Debug.Log(gamepad.name);
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

}
