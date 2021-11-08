using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Observer Planet Hand Item : Permet de montrer les plan�tes en forme d'item de main lors de la phase de combat
 */
public class OPHandItem : MonoBehaviour
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
        planetGameObject.GetComponent<SphereCollider>().enabled = false;
        planetGameObject.transform.localScale = new Vector3(40, 40, 1);

        planetGameObject.GetComponent<RandomMesh3d>().definePlanetStyle();
    }
}
