using UnityEngine;
using TMPro;
using UnityEngine.UI;

/* 
Ce script gère la création d'une carte à l'écran. Il s'agit d'un objet héritant de MonoBehaviour
qui prend les caractéristiques d'un objet planète pour les afficher sur le template de carte vierge.
*/


public class DisplayCard : MonoBehaviour
{


    [SerializeField] private Planet planet; // Objet planète
    [SerializeField] private TMP_Text planetName; // Nom de la planète
    [SerializeField] private TMP_Text activeEffect; // Nom de l'effet actif
    [SerializeField] private Image activeFrame; // Description de l'effet actif
    [SerializeField] private TMP_Text passiveEffect; // Texte de l'effet passif
    [SerializeField] private Image passiveFrame; // Description de l'effet passif
    [SerializeField] private Canvas planetAppareance; // Template de l'image

    private GameObject planetGameObject = null;

    private void Start()
    {
        //Display();
    }

    public void Display()
    {
        Destroy(planetGameObject);

        // Attribut chaque paramètre
        planetName.SetText(planet.title);
        activeEffect.SetText(planet.active.name);
        passiveEffect.SetText(planet.passive.name);
        activeEffect.color = planet.active.textColor;
        passiveEffect.color = planet.passive.textColor;
        activeFrame.color = planet.active.color;
        passiveFrame.color = planet.passive.color;
        planetGameObject = GameObject.Instantiate(planet.appearance, planetAppareance.transform);
        planetGameObject.GetComponent<SphereCollider>().enabled = false;
        planetGameObject.GetComponent<Bullet>().enabled = false;
        planetGameObject.transform.localScale = planetAppareance.transform.localScale * 200;
    }

    public void SetPlanet(Planet newPlanet)
    {
        planet = newPlanet;
    }

    public Planet GetPlanet()
    {
        return planet;
    }

}