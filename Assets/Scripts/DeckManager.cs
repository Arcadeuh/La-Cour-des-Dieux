using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{

    [SerializeField] private List<Planet> deck;
    [SerializeField] private List<OPHand> hand = new List<OPHand>(4);
    public GameObject player1;

    private List<Planet> planetsInHand = new List<Planet>(4) { null, null, null, null };
    private Planet planetSelected = null;
    private GameObject planetSelectedAttached = null;
    private Timer timer;

    private Queue<Planet> queue = new Queue<Planet>();

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<Timer>();
        timer.AddCallback(RefillQueueAndHand);
        UpdateHand();
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
        if (queue.Count == 0 && numberOfNull == 4)
        {
            timer.StartTimer(5.0f);
        }
        else { RefillHand(); }
        UpdateHandDisplay();
    }

    public bool isHandEmpty()
    {
        int numberOfNull = 0;
        foreach (Planet item in planetsInHand) { if (!item) { numberOfNull++; } }

        return (queue.Count == 0 && numberOfNull == 4);
    }

    private void RefillQueue()
    {
        Planet[] tempListPlanet = new Planet[deck.Count];
        deck.CopyTo(tempListPlanet);
        List<Planet> listPlanet = new List<Planet>(tempListPlanet);
        while (listPlanet.Count > 0)
        {
            int index = Random.Range(0, listPlanet.Count);
            queue.Enqueue(listPlanet[index]);
            listPlanet.RemoveAt(index);
        }
    }

    private void RefillHand()
    {
        for (int i = 0; i < 4; i++)
        {
            if (planetsInHand[i] == null)
            {
                if (queue.Count == 0)
                {
                    hand[i].SetPlanet(null);
                }
                else
                {
                    planetsInHand[i] = queue.Dequeue();
                    hand[i].SetPlanet(planetsInHand[i]);
                }
            }
        }
    }

    private void UpdateHandDisplay()
    {
        foreach(OPHand item in hand)
        {
            item.Display();
        }
    }

    private void RefillQueueAndHand()
    {
        RefillQueue();
        RefillHand();
        UpdateHandDisplay();
    }

    public void SelectPlanet(int i)
    {

        if (i >= planetsInHand.Count || i<0) { return; }
        planetSelected = planetsInHand[i];


       

        //If we chose one of the gamepad buttons to select a planet
        if (planetSelected)
        {
            Debug.Log("Planet selected : " + planetSelected.title);

            //If a planet was already attached to the player
            if (planetSelectedAttached)
            {
                Destroy(planetSelectedAttached);
            }

            planetSelectedAttached = Instantiate<GameObject>(planetSelected.appearance, player1.transform.position + player1.transform.forward * 3, player1.transform.rotation);

            // met transparance 
            planetSelectedAttached.GetComponent<PlanetBehaviour>().ChangeMaterialRenderingMode(planetSelectedAttached.GetComponent<MeshRenderer>().material, PlanetBehaviour.BlendMode.Transparent);
            
            // attache planete
            player1.GetComponent<TopDownMovement>().attach(planetSelectedAttached);
        }
    }



}
