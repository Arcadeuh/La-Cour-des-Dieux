using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusicOnStart : MonoBehaviour
{
    public bool stopEveryMusicOnPlay;
    public string musicTitle;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if (stopEveryMusicOnPlay) { audioManager.StopEverySounds(); }
        if (musicTitle == null || musicTitle=="") { return; }

        try
        {
            bool isPlaying = audioManager.IsPlaying(musicTitle);
            if (!isPlaying)
            {
                audioManager.Play(musicTitle);
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
    }
}
