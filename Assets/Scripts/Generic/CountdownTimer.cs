using System.Collections;
using TMPro;
using UnityEngine;



public class CountdownTimer : MonoBehaviour
{

    float currentTime = 0.0f;
    float startingTime = 5.0f;


    public TextMeshProUGUI textMeshPro;

    [SerializeField] private GameObject[] players;



    private void Start()
    {
        currentTime = startingTime;
        textMeshPro.text = currentTime.ToString("0");

        foreach( GameObject player in players)
        {
            player.GetComponent<TopDownShooter>().enabled = false ;
        }

    }

    private void Update()
    {

        currentTime -= 1 * Time.deltaTime;
        textMeshPro.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;

            foreach (GameObject player in players)
            {
                player.GetComponent<TopDownShooter>().enabled = true;
            }

            Destroy(gameObject);

        }


    }
}
