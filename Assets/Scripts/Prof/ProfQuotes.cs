using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProfQuotes : MonoBehaviour
{
    public List<string> listeCitations = new List<string>();
    [SerializeField] public TMP_Text citationAffichee;
    int index;
    

    void Start(){
        index = Random.Range(0, listeCitations.Count);
        citationAffichee.SetText(listeCitations[index]);
    }
}