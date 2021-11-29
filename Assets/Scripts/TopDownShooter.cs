using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TopDownShooter : MonoBehaviour
{
    public Animator characterAnimator;
    public bool shielded = false;
    public List<GameObject> shields = null;
    private DeckManager deckManager;     
    [SerializeField] private float bulletForce = 15.0f;     // force à laquel on envoie la planete
    private AudioManager audioManager;

    private void Start()
    {
        deckManager = GetComponent<DeckManager>();
        if (!deckManager) { Debug.LogError("No Deck Mnager in TopDownShooter"); }
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if (!audioManager) { Debug.LogError("No AudioManager found"); }
    }

    public void OnSouth(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid() ||  !enabled ) { return; }    // avoid to create things with Player Input manager
        if (context.performed)
        {
            deckManager.SelectPlanet(3);

            // animation 
            characterAnimator.SetBool("PlaneteSelected", true);

        }
    }
    public void OnEast(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid() ||  !enabled) { return; }    // avoid to create things with Player Input manager
        if (context.performed)
        {
            deckManager.SelectPlanet(2);

            // animation 
            characterAnimator.SetBool("PlaneteSelected", true);

        }
    }
    public void OnWest(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid() ||  !enabled) { return; }    // avoid to create things with Player Input manager
        if (context.performed)
        {
            deckManager.SelectPlanet(1);

            // animation 
            characterAnimator.SetBool("PlaneteSelected", true);

        }
    }
    public void OnNorth(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid() ||  !enabled) { return; }    // avoid to create things with Player Input manager
        if (context.performed)
        {
            deckManager.SelectPlanet(0);

            // animation 
            characterAnimator.SetBool("PlaneteSelected", true);

        }
    }

    // tirer
    public void OnShoulderRight(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid() ||  !enabled ) { return; }    // avoid to create things with Player Input manager

        if (context.performed && deckManager.GetPlanetSelected())
        {
            Debug.Log("Fire");

            // animation 
            characterAnimator.SetBool("PlaneteSelected", false);
            characterAnimator.SetTrigger("ThrowPlanet");
            //characterAnimator.ResetTrigger("ThrowPlanet");



            //Debug.Log(deckManager.GetPlanetSelected().active.name);

            GameObject planet = GetComponent<TopDownMovement>().PlanetAttached; // on recup la planete

            planet.GetComponent<Bullet>().bulletForce = bulletForce;
            planet.GetComponent<Bullet>().forwardVector = transform.forward; //On récupérer dans le script de la planète son vecteur de déplacement pour les scripts des effets

            planet.AddComponent(Type.GetType(deckManager.GetPlanetSelected().active.name)); //On lui donne le script d'effet actif
            GetComponent<TopDownMovement>().detach();   // on la detache de la main
            deckManager.DeletePlanetSelected();         // on la supp du deck

            Rigidbody rb = planet.GetComponent<Rigidbody>(); // on recup rigidbody
            rb.AddForce(transform.forward * bulletForce, ForceMode.Impulse);    // On envoie la planete

            planet.tag = gameObject.name + "Planets"; //on identifie cette planète comme appartenant a ce joueur (Player1 ou Player2) pour les zones d"effets

            audioManager.Play("Attack");
        }

        SaveSystem.p1GamePad.SetMotorSpeeds(0.2f, 0.4f);
    }

    // defendre
    public void OnShoulderLeft(InputAction.CallbackContext context)
    {
        
        Debug.Log("Def planet");
        if (!gameObject.scene.IsValid() ||  !enabled ) { return; }    // avoid to create things with Player Input manager
        if (context.performed && deckManager.GetPlanetSelected())
        {

            // animation 
            characterAnimator.SetBool("PlaneteSelected", false);
            characterAnimator.SetTrigger("PlacePlanet");
            //characterAnimator.ResetTrigger("PlacePlanet");

            Debug.Log(deckManager.GetPlanetSelected().passive.name);
            GameObject planet = GetComponent<TopDownMovement>().PlanetAttached; // on recup la planete

            planet.AddComponent(Type.GetType(deckManager.GetPlanetSelected().passive.name)); //On lui donne le script d'effet passif
            planet.GetComponent<Bullet>().setIsDefense(true);

            planet.GetComponent<Bullet>().bulletForce = bulletForce;
            planet.GetComponent<Bullet>().forwardVector = transform.forward; //On récupérer dans le script de la planète son vecteur de déplacement pour les scripts des effets

            planet.tag = gameObject.name + "Planets"; //on identifie cette planète comme appartenant a ce joueur (Player1 ou Player2) pour les zones d"effets

            GetComponent<TopDownMovement>().detach();

            deckManager.DeletePlanetSelected();

            audioManager.Play("Defense");
        }
    }

}
