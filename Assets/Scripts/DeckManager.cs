using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Créer, recharge le deck d'un joueur
 */
public class DeckManager : MonoBehaviour
{
    //Deck de base
    [SerializeField] private List<Planet> deckInit;
    //Liste pour afficher les planètes
    private List<OPHandItem> hand = new List<OPHandItem>(4);

    //La main, liste de planètes à jouer pour le joueur
    private List<Planet> planetsInHand = new List<Planet>(4) { null, null, null, null };
    private Planet planetSelected = null;
    private Timer timer;

    //Deck, se vidant au fur et à mesure
    private Queue<Planet> deck = new Queue<Planet>();

    void Start()
    {
        GameObject player = GameObject.Find("UI/Player1");
        if (player.GetComponent<LinkToDeckManager>().IsLinked())
        {
            player = GameObject.Find("UI/Player2");
        }
        OPHandItem[] hand = player.GetComponentsInChildren<OPHandItem>();
        for(int i = 0; i < hand.Length; i++)
        {
            this.hand.Add(hand[i]);
        }

        timer = GetComponent<Timer>();
        timer.AddCallback(RefillQueueAndHand); //Callback appelée à la fin du timer
        RefillQueueAndHand(); //Refill le deck et la main
        UpdateHand(); //Update l'affichage
    }

    public void DeletePlanetSelected()
    {
        if (!planetSelected) { return; }
        planetsInHand[planetsInHand.IndexOf(planetSelected)] = null;
        planetSelected = null;
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
        if (i >= planetsInHand.Count || i<0) { return; }
        planetSelected = planetsInHand[i];
        Debug.Log(planetSelected.title + " is selected");
    }
}
