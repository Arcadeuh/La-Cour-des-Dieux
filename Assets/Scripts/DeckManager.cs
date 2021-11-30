using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/*
 * Créer, recharge le deck d'un joueur
 */
public class DeckManager : MonoBehaviour
{
    //Deck de base
    [SerializeField] private List<Planet> deckInit;     // liste des planete dans le deck au début

    
    private List<OPHandItem> hand = new List<OPHandItem>(4); //Liste pour afficher les planètes
    
    private List<Planet> planetsInHand = new List<Planet>(4) { null, null, null, null }; //La main, liste de planètes à jouer pour le joueur
    private Planet planetSelected = null;   
    private GameObject planetSelectedAttached = null;
    private Timer timer;
    private GameObject playerUI;

    //Deck, se vidant au fur et à mesure
    private Queue<Planet> deck = new Queue<Planet>();

    void Awake()
    {
        /*
        ControllerData cd = SaveSystem.LoadControllerData();
        if (cd == null) { Debug.LogError("Pas de controllers sauvegardés"); return; }

        // defini si c'est l'ui du player 1 ou du player 2
        InputDevice inputDevice = GetComponent<PlayerInput>().devices[0];
        Gamepad presentGamepad = (Gamepad)InputSystem.GetDeviceById(inputDevice.deviceId);
        
        if (cd.controllerP1 == presentGamepad.name)
        {
            playerUI = GameObject.Find("UI/Player1");
            transform.position = playerUI.transform.position + new Vector3(20, 0, 0);
            //playerUI.GetComponent<LinkToDeckManager>().DoLink();
        }
        else if (cd.controllerP2 == presentGamepad.name)
        {
            playerUI = GameObject.Find("UI/Player2");
            transform.position = playerUI.transform.position - new Vector3(20, 0, 0);
            //playerUI.GetComponent<LinkToDeckManager>().DoLink();
        }
        else { Debug.LogError("The gameObject name is not 'Player1' nor 'Player2'"); return; }
        */

        if (gameObject.name == "Player1"){ playerUI = GameObject.Find("UI/Player1"); }
        else if (gameObject.name == "Player2") { playerUI = GameObject.Find("UI/Player2"); }
        else { Debug.LogError("The gameObject name is not 'Player1' nor 'Player2'"); return; }

        timer = GetComponent<Timer>();
        timer.AddEndCallback(RefillQueueAndHand);  //Callback appelée à la fin du timer
        timer.AddEndCallback(InactiveTimerUI);
        timer.AddBeginCallback(ActiveTimerUI);

        // link la main
        OPHandItem[] hand = playerUI.GetComponentsInChildren<OPHandItem>();   // recupère toutes les OPHand
        for(int i = 0; i < hand.Length; i++)
        {
            this.hand.Add(hand[i]);     // On les save dans la main
        }
        
        //RefillQueueAndHand();                   //Refill le deck et la main
    }

    public void SetDeckInit(List<Planet> planets)
    {
        Planet[] tempListPlanet = new Planet[planets.Count];
        planets.CopyTo(tempListPlanet);
        deckInit = new List<Planet>(tempListPlanet);
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
        RefillHand();
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
            item.SetSelected(false);
        }
    }

    public void RefillQueueAndHand()
    {
        RefillDeck();
        RefillHand();
        UpdateHandDisplay();
    }

    public void ActiveTimerUI()
    {
        playerUI.transform.Find("Timer").gameObject.SetActive(true);
    }

    public void InactiveTimerUI()
    {
        playerUI.transform.Find("Timer").gameObject.SetActive(false);
    }

    public void SelectPlanet(int i)
    {
        
        if (i >= planetsInHand.Count || i<0) { return; }    // si il n'y a plus de planete

        //If we chose one of the gamepad buttons to select a planet
        if (planetsInHand[i])
        {
            for(int j = 0; j<hand.Count; j++)
            {
                if (j == i) { 
                    hand[j].SetSelected(true);
                    continue;
                }
                hand[j].SetSelected(false);
            }

            planetSelected = planetsInHand[i];
            Debug.Log(planetSelected.title + " is selected");
            //If a planet was already attached to the player
            if (planetSelectedAttached)
            {
                Destroy(planetSelectedAttached);
            }

            planetSelectedAttached = Instantiate<GameObject>(planetSelected.appearance, transform.position + transform.forward * 2, transform.rotation);

            planetSelectedAttached.GetComponent<PlanetMaterialBehaviour>().ChangeMaterialsRenderingMode(PlanetMaterialBehaviour.BlendMode.Transparent);
            GetComponent<TopDownMovement>().attach(planetSelectedAttached);
        }
    }

    public void PrintDeckInit() // debug fonction
    {
        Debug.Log("~~~~PLANETS INSIDE DECK INIT~~~~");
        foreach(Planet planet in deckInit)
        {
            Debug.Log(planet.title);
        }
    }

    private void Update()
    {
        GameObject timerUI = playerUI.transform.Find("Timer").gameObject;
        Debug.Log(timerUI.activeInHierarchy);
        if (timerUI.activeInHierarchy)
        {
            timerUI.GetComponent<TMP_Text>().SetText(Mathf.Round(timer.GetCurrentTime() + 1).ToString());
        }
    }
}

