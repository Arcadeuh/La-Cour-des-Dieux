using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMainMenuStart : MonoBehaviour
{
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        try
        {
            bool isPlaying = audioManager.IsPlaying("IntroMusic");
            if (!isPlaying)
            {
                audioManager.Play("IntroMusic");
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}
