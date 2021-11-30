using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnStartEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent onStart = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        onStart.Invoke();
    }
}
