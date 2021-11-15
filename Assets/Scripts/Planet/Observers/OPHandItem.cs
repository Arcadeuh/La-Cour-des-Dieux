using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// -----------------------------
// OBSERVEUR D'UNE PLANETE
// -----------------------------

public class OPHandItem : MonoBehaviour
/*
 * Observer Planet Hand Item : Permet de montrer les planetes en forme d'item de main lors de la phase de combat
 */
{
    [SerializeField] private TMP_Text planetName; // Nom de la planète
    [SerializeField] private TMP_Text activeEffect; // Effet actif
    [SerializeField] private TMP_Text passiveEffect; // Effet passif
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
            activeEffect.SetText("None");
            passiveEffect.SetText("None");
            return;
        }

        planetName.SetText(planet.title);               // show Planete name in UI
        activeEffect.SetText(planet.active.title);      // show Planete active effect in UI
        passiveEffect.SetText(planet.passive.title);    // show Planete passive effect in UI

        planetGameObject = GameObject.Instantiate(planet.appearance, planetCanvas.transform);   // on creer le game object planete
        planetGameObject.GetComponent<SphereCollider>().enabled = false;
        planetGameObject.transform.localScale = new Vector3(80, 80, 1);

        //planetGameObject.GetComponent<RandomMesh3d>().definePlanetStyle();
    }

    public void SetSelected(bool isSelected)
    {
        selectedSprite.SetActive(isSelected);
    }
}
