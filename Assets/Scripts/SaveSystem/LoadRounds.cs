using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRounds : MonoBehaviour
{
    [SerializeField] private ScoreProgress scoreProgress;

    // Start is called before the first frame update
    void Awake()
    {
        RoundsData rd = SaveSystem.LoadRoundsData();
        scoreProgress.SetVictoriesNumber(rd.victoryCountP1, rd.victoryCountP2);
        scoreProgress.SetRoundNumber(rd.victoryCountP1 + rd.victoryCountP2 + 1);
    }
}
