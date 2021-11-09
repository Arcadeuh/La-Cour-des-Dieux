using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TopDownShooter : MonoBehaviour
{
    private DeckManager deckManager;     
    [SerializeField] private float bulletForce = 15.0f;     // force à laquel on envoie la planete

    private void Start()
    {
        deckManager = GetComponent<DeckManager>();
        if (!deckManager) { Debug.LogError("No Deck Mnager in TopDownShooter"); }
    }

    public void OnSouth(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid() ||  !enabled ) { return; }    // avoid to create things with Player Input manager
        if (context.performed)
        {
            deckManager.SelectPlanet(3);
        }
    }
    public void OnEast(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid() ||  !enabled) { return; }    // avoid to create things with Player Input manager
        if (context.performed)
        {
            deckManager.SelectPlanet(2);
        }
    }
    public void OnWest(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid() ||  !enabled) { return; }    // avoid to create things with Player Input manager
        if (context.performed)
        {
            deckManager.SelectPlanet(1);
        }
    }
    public void OnNorth(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid() ||  !enabled) { return; }    // avoid to create things with Player Input manager
        if (context.performed)
        {
            deckManager.SelectPlanet(0);
        }
    }

    // tirer
    public void OnShoulderRight(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid() ||  !enabled ) { return; }    // avoid to create things with Player Input manager

        if (context.performed && deckManager.GetPlanetSelected())
        {
            Debug.Log("Fire");
            Debug.Log(deckManager.GetPlanetSelected().active.name);
            
            GameObject planet = GetComponent<TopDownMovement>().PlanetAttached; // on recup la planete

            planet.GetComponent<Bullet>().bulletForce = bulletForce;
            planet.AddComponent(Type.GetType(deckManager.GetPlanetSelected().active.name)); //On lui donne le script d'effet actif
            GetComponent<TopDownMovement>().detach();   // on la detache de la main
            deckManager.DeletePlanetSelected();         // on la supp du deck

            Rigidbody rb = planet.GetComponent<Rigidbody>();                    // on recup rigidbody
            rb.AddForce(transform.forward * bulletForce, ForceMode.Impulse);    // On envoie la planete
        }
    }

    // defendre
    public void OnShoulderLeft(InputAction.CallbackContext context)
    {
        Debug.Log("Def planet");
        if (!gameObject.scene.IsValid() ||  !enabled ) { return; }    // avoid to create things with Player Input manager
        if (context.performed && deckManager.GetPlanetSelected())
        {
            Debug.Log(deckManager.GetPlanetSelected().passive.name);
            GameObject planet = GetComponent<TopDownMovement>().PlanetAttached; // on recup la planete

            planet.AddComponent(Type.GetType(deckManager.GetPlanetSelected().passive.name)); //On lui donne le script d'effet passif
            planet.GetComponent<Bullet>().setIsDefense(true);
            GetComponent<TopDownMovement>().detach();

            deckManager.DeletePlanetSelected();
        }
    }

}
