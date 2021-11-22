using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryPoints : MonoBehaviour
{
    [SerializeField] private List<GameObject> points;
    private int victoryPoints = 0;

    public void SetVictoryPoints(int points)
    {
        victoryPoints = points;
    }

    public void UpdateUI()
    {
        for (int i = 0; i < victoryPoints; i++)
        {
            if (i > points.Count) { break; }
            points[i].transform.Find("PointObtained").gameObject.SetActive(true);
        }
    }
}
