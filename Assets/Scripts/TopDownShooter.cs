using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
///  Gestion des Input Pour Tirer
///  On Recupere les touches on on applique les fonctions : 
///  Selection des planetes
///  lancer les planetes
/// </summary>

public class TopDownShooter : MonoBehaviour
{
    private DeckManager deckManager;

    float bulletForce = 2.0f;


    private void Start()
    {
        deckManager = GameObject.Find("DeckManager").GetComponent<DeckManager>();
        if (!deckManager)
        {
            Debug.LogError("PAS DE DECK MANAGER DANS TOP DOWN SHOOTER");
        }
    }

    public void OnSouth(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid()) { return; }    // avoid to create things with Player Input manager
        if (!context.performed) { return; }
        if (!deckManager) { return; }
        if (deckManager.isHandEmpty()) { return; }
        {
            deckManager.SelectPlanet(3);
        }
    }
    public void OnEast(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid()) { return; }    // avoid to create things with Player Input manager
        if (!context.performed) { return; }
        if (!deckManager) { return; }
        if (deckManager.isHandEmpty()) { return; }
        {
            deckManager.SelectPlanet(2);
        }
    }
    public void OnWest(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid()) { return; }    // avoid to create things with Player Input manager
        if (!context.performed) { return; }
        if (!deckManager) { return; }
        if (deckManager.isHandEmpty()) { return; }
        {
            deckManager.SelectPlanet(1);
        }
    }
    public void OnNorth(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid()) { return; }    // avoid to create things with Player Input manager
        if (!context.performed) { return; }
        if (!deckManager) { return; }
        if (deckManager.isHandEmpty()) { return; }
        {
            deckManager.SelectPlanet(0);
        }
    }

    public void OnShoulderRight(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid()) { return; }    // avoid to create things with Player Input manager
        if (context.performed)
        {
            if (! deckManager.GetPlanetSelected()) { return; }  // si pas de planete selectionne, fin
            Debug.Log("Fire");
            GameObject planet =  Instantiate<GameObject>(deckManager.GetPlanetSelected().appearance, transform.position + transform.forward * 4, transform.rotation);
            deckManager.DeletePlanetSelected();

            Rigidbody rb = planet.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * bulletForce, ForceMode.Impulse);


        }
    }
}
