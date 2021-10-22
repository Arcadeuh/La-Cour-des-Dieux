using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SelectDeletePlanet : MonoBehaviour
{
    public UnityEvent pressKeyA;
    public UnityEvent pressKeyQ;
    public UnityEvent pressKeyS;
    public UnityEvent pressKeyD;
    public UnityEvent pressKeyF;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("pressing A");
            pressKeyA.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            pressKeyQ.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            pressKeyS.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            pressKeyD.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            pressKeyF.Invoke();
        }
    }
}
