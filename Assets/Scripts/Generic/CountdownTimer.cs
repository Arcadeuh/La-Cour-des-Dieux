using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownTimer : MonoBehaviour
{

    float currentTime = 0.0f;
    float startingTime = 5.0f;

    public TextMeshProUGUI textMeshPro;



    private void Start()
    {
        currentTime = startingTime;
        textMeshPro.text = currentTime.ToString("0");

    }

    private void Update()
    {

        currentTime -= 1 * Time.deltaTime;
        textMeshPro.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
            Destroy(gameObject);

        }


    }
}
