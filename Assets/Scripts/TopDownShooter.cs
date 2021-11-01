using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class TopDownShooter : MonoBehaviour
{
    private DeckManager deckManager;
    float bulletForce = 8.0f;

    private void Start()
    {
        deckManager = GetComponent<DeckManager>();
        if (!deckManager) { Debug.LogError("No Deck Mnager in TopDownShooter"); }
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

    // tiré
    public void OnShoulderRight(InputAction.CallbackContext context)
    {
        if (!gameObject.scene.IsValid()) { return; }    // avoid to create things with Player Input manager
        if (context.performed && deckManager.GetPlanetSelected())
        {
            Debug.Log("Fire");
            //GameObject planet = Instantiate<GameObject>(deckManager.GetPlanetSelected().appearance, transform.position + transform.forward * 4, transform.rotation);

            GameObject planet = GetComponent<TopDownMovement>().planetAttached; // on recup la planete
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
        if (!gameObject.scene.IsValid()) { return; }    // avoid to create things with Player Input manager
        if (context.performed && deckManager.GetPlanetSelected())
        {

            GetComponent<TopDownMovement>().planetAttached.GetComponent<Bullet>().setIsDefense(true);
            GetComponent<TopDownMovement>().detach();

            deckManager.DeletePlanetSelected();
        }
    }

}
