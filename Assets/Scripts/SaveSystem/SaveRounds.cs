using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveRounds : MonoBehaviour
{
    public void SaveRoundsMethod(int victoryCountP1, int victoryCountP2)
    {
        SaveSystem.SaveRoundsData(victoryCountP1, victoryCountP2);
    }
    public void SaveInitRounds()
    {
        SaveSystem.SaveRoundsData(0, 0);
    }
}
