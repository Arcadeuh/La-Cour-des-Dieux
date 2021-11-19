using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

// -----------------------------
// OBSERVEUR D'UNE PLANETE
// -----------------------------

public class OPHandItem : MonoBehaviour
/*
 * Observer Planet Hand Item : Permet de montrer les planetes en forme d'item de main lors de la phase de combat
 */
{
    [SerializeField] private TMP_Text planetName; // Nom de la planète
    [SerializeField] private TMP_Text activeText; // Effet actif
    [SerializeField] private TMP_Text passiveText; // Effet passif
    [SerializeField] private Image activeBack; // Effet actif
    [SerializeField] private Image passiveBack; // Effet passif
    [SerializeField] private Canvas planetCanvas; // Pour l'instant c'est temporaire
    [SerializeField] private GameObject selectedSprite; // Encadré de sélection

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
            activeText.SetText("None");
            passiveText.SetText("None");
            activeBack.enabled = false;
            passiveBack.enabled = false;
            activeText.color = Color.white;
            passiveText.color = Color.white;
            return;
        }

        planetName.SetText(planet.title);               // show Planete name in UI
        activeText.SetText(planet.active.title);      // show Planete active effect in UI
        passiveText.SetText(planet.passive.title);    // show Planete passive effect in UI

        planetGameObject = GameObject.Instantiate(planet.appearance, planetCanvas.transform);   // on creer le game object planete
        planetGameObject.GetComponent<SphereCollider>().enabled = false;
        planetGameObject.GetComponent<Bullet>().enabled = false;
        planetGameObject.transform.localScale = new Vector3(80, 80, 1);

        activeBack.enabled = true;
        passiveBack.enabled = true;

        activeBack.color = planet.active.color;
        passiveBack.color = planet.passive.color;
        activeText.color = planet.active.textColor;
        passiveText.color = planet.passive.textColor;

        //planetGameObject.GetComponent<RandomMesh3d>().definePlanetStyle();
    }

    public void SetSelected(bool isSelected)
    {
        selectedSprite.SetActive(isSelected);
    }
}
