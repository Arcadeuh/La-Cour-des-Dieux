using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private List<Planet> deck;
    [SerializeField] private List<OPHand> hand;

    private List<Planet> planetsInHand;

    private Queue<Planet> queue = new Queue<Planet>();

    // Start is called before the first frame update
    void Start()
    {
        planetsInHand = new List<Planet>();
        UpdateHand();
    }

    void Delete(Planet planet)
    {
        planetsInHand.Remove(planet);
        UpdateHand();
    }

    void UpdateHand()
    {
        //When everything is empty
        if(queue.Count == 0 && planetsInHand.Count == 0)
        {
            List<Planet> listPlanet = deck;
            while (listPlanet.Count>0)
            {
                int index = Random.Range(0, listPlanet.Count);
                queue.Enqueue(listPlanet[index]);
                listPlanet.RemoveAt(index);
            }
        }

        //When it miss cards in hand
        while (planetsInHand.Count < hand.Count)
        {
            if (queue.Count == 0) { break; }
            planetsInHand.Add(queue.Dequeue());
        }

        for (int i = 0; i<planetsInHand.Count; i++)
        {
            Planet copyPlanet = planetsInHand[i];
            hand[i].SetPlanet(copyPlanet);
        }
    }
}
