using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * A CLASS JUST FOR TESTING DECKTOSHOW SCRIPT
 * Should be replace by the real script for displaying planets
 */
public class TestCard : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private Planet planet;

    public void Display() //Show the planet
    {
        text.SetText(planet.title);
    }

    public void SetPlanet(Planet newPlanet)
    {
        planet = newPlanet;
    }
}
