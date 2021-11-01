using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;


public class Timer : MonoBehaviour
{
    public UnityEvent endTimer;

    private float currentTime;
    private bool isRunning = false;


    //~~~~~~Timer methods~~~~~~
    public void StartTimer(float time)
    {
        currentTime = time;
        isRunning = true;
    }

    public void StartTimer()
    {
        if (currentTime <= 0.0f) { throw new Exception("Please set a time to decount"); }
        isRunning = true;
    }

    public void SetTimer(float time)
    {
        currentTime = time;
    }

    public void PauseTimer()
    {
        isRunning = false;
    }

    public void StopTimer()
    {
        isRunning = false;
        currentTime = 0.0f;
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }


    //~~~~~~Callbacks methods~~~~~~
    public void AddCallback(UnityAction callback)
    {
        endTimer.AddListener(callback);
        Debug.Log("HERE");
    }

    public void RemoveCallbacks(UnityAction callback)
    {
        endTimer.RemoveAllListeners();
    }

    //~~~~~~LOOP~~~~~~
    public void Update()
    {
        if (isRunning)
        {
            if (currentTime <= 0.0f)
            {
                endTimer.Invoke();
                StopTimer();
                return;
            }
            currentTime -= Time.deltaTime;
        }
    }
}
