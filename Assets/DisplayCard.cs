using UnityEngine;
using TMPro;

/* 
Ce script gère la création d'une carte à l'écran. Il s'agit d'un objet héritant de MonoBehaviour
qui prend les caractéristiques d'un objet planète pour les afficher sur le template de carte vierge.
*/


public class DisplayCard : MonoBehaviour
{


    [SerializeField] private Planet planet; // Objet planète
    [SerializeField] private TMP_Text planetName; // Nom de la planète
    [SerializeField] private TMP_Text activeEffect; // Nom de l'effet actif
    [SerializeField] private TMP_Text activeEffectDescription; // Description de l'effet actif
    [SerializeField] private TMP_Text passiveEffect; // Texte de l'effet passif
    [SerializeField] private TMP_Text passiveEffectDescription; // Description de l'effet passif
    [SerializeField] private GameObject planetAppareance; // Template de l'image

    // Méthode d'affichage de carte sur l'écran. Nom en frnaçais parce qu'il veut pas DisplayCard
    void AffichageCarte()
    {
        // Attribut chaque paramètre
        planetName.SetText(planet.title);
        activeEffect.SetText(planet.active.name);
        passiveEffectDescription.SetText(planet.passive.description);
        activeEffectDescription.SetText(planet.active.description);
        passiveEffect.SetText(planet.passive.name);
        planetAppareance = planet.appearance;
        Instantiate(planetAppareance, new Vector3(0, 0, 7.0f), Quaternion.identity);
    }

}