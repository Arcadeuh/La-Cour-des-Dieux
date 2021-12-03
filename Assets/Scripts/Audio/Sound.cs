using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip audio;

    [Range(0.0f, 1.0f)]
    public float volume = 1.0f;
    [Range(0.1f, 3.0f)]
    public float pitch = 0.1f;
    public bool loop = false;

    [HideInInspector]
    public AudioSource source;
}
