using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OPHand : MonoBehaviour
{
    [SerializeField] private TMP_Text planetName;
    [SerializeField] private TMP_Text activeEffect;
    [SerializeField] private TMP_Text passiveEffect;
    [SerializeField] private Canvas planetCanvas;

    [SerializeField] private Planet planet;

    private GameObject planetGameObject = null;

    // Start is called before the first frame update
    void Start()
    {
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
