using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Cr�er, recharge le deck d'un joueur
 */
public class DeckManager : MonoBehaviour
{
    //Deck de base
    [SerializeField] private List<Planet> deckInit;

    //Liste pour afficher les plan�tes
    private List<OPHandItem> hand = new List<OPHandItem>(4);


    

    //La main, liste de plan�tes � jouer pour le joueur
    private List<Planet> planetsInHand = new List<Planet>(4) { null, null, null, null };
    private Planet planetSelected = null;
    private GameObject planetSelectedAttached = null;
    private Timer timer;

    //Deck, se vidant au fur et � mesure
    private Queue<Planet> deck = new Queue<Planet>();

    void Start()
    {
        // defini si c'est l'ui du player 1 ou du player 2
        GameObject player = GameObject.Find("UI/Player1");
        if (player.GetComponent<LinkToDeckManager>().IsLinked())
        {
            player = GameObject.Find("UI/Player2");
        }
        player.GetComponent<LinkToDeckManager>().DoLink();

        // link la main
        OPHandItem[] hand = player.GetComponentsInChildren<OPHandItem>();   // recup�re toutes les OPHand
        Debug.Log(hand.Length);
        for(int i = 0; i < hand.Length; i++)
        {
            this.hand.Add(hand[i]);     // On les save dans la main
        }

        timer = GetComponent<Timer>();
        timer.AddCallback(RefillQueueAndHand);  //Callback appel�e � la fin du timer
        RefillQueueAndHand();                   //Refill le deck et la main
        UpdateHand();                           //Update l'affichage
    }

    public void DeletePlanetSelected()
    {
        if (!planetSelected) { return; }
        planetsInHand[planetsInHand.IndexOf(planetSelected)] = null;
        planetSelected = null;
        planetSelectedAttached = null;
        UpdateHand();
    }

    public Planet GetPlanetSelected()
    {
        return planetSelected;
    }

    void UpdateHand()
    {
        int numberOfNull = 0;
        foreach(Planet item in planetsInHand) { if (!item) { numberOfNull++; } }
        //Si le 
        if (deck.Count == 0 && numberOfNull == 4)
        {
            timer.StartTimer(5.0f);
        }
        else { RefillHand(); }
        UpdateHandDisplay();
    }

    private void RefillDeck()
    {
        Planet[] tempListPlanet = new Planet[deckInit.Count];
        deckInit.CopyTo(tempListPlanet);
        List<Planet> listPlanet = new List<Planet>(tempListPlanet);
        while (listPlanet.Count > 0)
        {
            int index = Random.Range(0, listPlanet.Count);
            deck.Enqueue(listPlanet[index]);
            listPlanet.RemoveAt(index);
        }
    }

    private void RefillHand()
    {
        for (int i = 0; i < 4; i++)
        {
            if (planetsInHand[i] == null)
            {
                if (deck.Count == 0)
                {
                    hand[i].SetPlanet(null);
                }
                else
                {
                    planetsInHand[i] = deck.Dequeue();
                    hand[i].SetPlanet(planetsInHand[i]);
                }
            }
        }
    }

    private void UpdateHandDisplay()
    {
        foreach(OPHandItem item in hand)
        {
            item.Display();
        }
    }

    private void RefillQueueAndHand()
    {
        RefillDeck();
        RefillHand();
        UpdateHandDisplay();
    }

    public void SelectPlanet(int i)
    {
        
        if (i >= planetsInHand.Count || i<0) { return; }    // si il n'y a plus de planete
        planetSelected = planetsInHand[i];
        Debug.Log(planetSelected.title + " is selected");


        //If we chose one of the gamepad buttons to select a planet
        if (planetSelected)
        {
            Debug.Log("Planet selected : " + planetSelected.title);

            //If a planet was already attached to the player
            if (planetSelectedAttached)
            {
                Destroy(planetSelectedAttached);
            }

            planetSelectedAttached = Instantiate<GameObject>(planetSelected.appearance, transform.position + transform.forward * 2, transform.rotation);

            planetSelectedAttached.GetComponent<PlanetBehaviour>().ChangeMaterialRenderingMode(planetSelectedAttached.GetComponent<MeshRenderer>().material, PlanetBehaviour.BlendMode.Transparent);
            GetComponent<TopDownMovement>().attach(planetSelectedAttached);
        }
    }
}

