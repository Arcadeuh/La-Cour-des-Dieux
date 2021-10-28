using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TopDownShooter : MonoBehaviour
{
    private DeckManager deckManager;

    private void Start()
    {
        deckManager = GameObject.Find("DeckManager").GetComponent<DeckManager>();
    }

    public void OnSouth(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid()) { return; }    // avoid to create things with Player Input manager
        if (context.performed)
        {
            deckManager.SelectPlanet(3);
        }
    }
    public void OnEast(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid()) { return; }    // avoid to create things with Player Input manager
        if (context.performed)
        {
            deckManager.SelectPlanet(2);
        }
    }
    public void OnWest(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid()) { return; }    // avoid to create things with Player Input manager
        if (context.performed)
        {
            deckManager.SelectPlanet(1);
        }
    }
    public void OnNorth(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid()) { return; }    // avoid to create things with Player Input manager
        if (context.performed)
        {
            deckManager.SelectPlanet(0);
        }
    }


    public void OnShoulderRight(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid()) { return; }    // avoid to create things with Player Input manager
        if (context.performed && deckManager.GetPlanetSelected())
        {
            Instantiate<GameObject>(deckManager.GetPlanetSelected().appearance, transform.position + transform.forward * 2, transform.rotation);
            deckManager.DeletePlanetSelected();
        }
    }


    public void OnShoulderLeft(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid()) { return; }    // avoid to create things with Player Input manager
        if (context.performed && deckManager.GetPlanetSelected())
        {
            Instantiate<GameObject>(deckManager.GetPlanetSelected().appearance, transform.position + transform.forward * 2, transform.rotation);
            deckManager.DeletePlanetSelected();
        }
    }

}
