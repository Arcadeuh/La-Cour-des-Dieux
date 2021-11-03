using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "NewCard")]
public class DisplayCard : MonoBehaviour
{


    [SerializeField] private Planet planet; // Objet planete

    [SerializeField] private TMP_Text planetName; // Nom de la planète
    [SerializeField] private TMP_Text activeEffect; // Texte de l'effet actif
    [SerializeField] private TMP_Text passiveEffect; // Texte de l'effet passif
    [SerializeField] private Image template; // Template de l'image

    private GameObject planetGameObject = null;

    void Start()
    {
        planetName.SetText(planet.title);
        activeEffect.SetText(planet.active.name);
        passiveEffect.SetText(planet.passive.name);
    }

}