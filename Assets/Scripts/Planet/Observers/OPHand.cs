using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// -----------------------------
// OBSERVEUR D'UNE PLANETE
// -----------------------------

public class OPHand : MonoBehaviour
{
    [SerializeField] private TMP_Text planetName; // Nom de la planète
    [SerializeField] private TMP_Text activeEffect; // Effet actif
    [SerializeField] private TMP_Text passiveEffect; // Effet passif
    [SerializeField] private Canvas planetCanvas; // Pour l'instant c'est temporaire

    [SerializeField] private Planet planet; // Objet planete

    private GameObject planetGameObject = null;

    // Start is called before the first frame update
    void Start()
    {
        // Créé si non nul
        if (planet == null) { return; }
        
        Display();
    }

    public void SetPlanet(Planet newPlanet)
    {
        planet = newPlanet;
    }

    public void Display()
    {
        Destroy(planetGameObject);

        if (!planet)
        {
            planetName.SetText("None");
            activeEffect.SetText("None");
            passiveEffect.SetText("None");
            return;
        }

        planetName.SetText(planet.title);
        activeEffect.SetText(planet.active.title);
        passiveEffect.SetText(planet.passive.title);
        planetGameObject = GameObject.Instantiate(planet.appearance, planetCanvas.transform);
        planetGameObject.transform.localScale = new Vector3(40, 40, 1);
    }
}
