using System.Collections;
using TMPro;
using UnityEngine;



public class CountdownTimer : MonoBehaviour
{

    float currentTime = 0.0f;       // le temps reel
    float startingTime = 5.0f;      // le temps a attendre pour lancer la partie


    public TextMeshProUGUI textMeshPro;                 // le texte pour afficher le décompte

    [SerializeField] private GameObject[] players;      // les deux joueurs



    private void Start()
    {
        currentTime = startingTime;                     // On fixe le temps à attendre
        textMeshPro.text = currentTime.ToString("0");   // On affiche le start time

        foreach( GameObject player in players)
        {
            player.GetComponent<TopDownShooter>().enabled = false ;     // On empeche aux joueurs de tirer avant la fin du compteur
        }

    }

    private void Update()
    {

        currentTime -= 1 * Time.deltaTime;              // update le chrono
        textMeshPro.text = currentTime.ToString("0");   // On affiche le temps

        if(currentTime <= 0)        // si le chrono est fini
        {
            currentTime = 0;        // On bloque le current time pour eviter tout bug d'affichage

            foreach (GameObject player in players)
            {
                player.GetComponent<TopDownShooter>().enabled = true;       // On permet aux joueurs de tirer
            }

            Destroy(gameObject);        // On supprime le timer.

        }


    }
}
