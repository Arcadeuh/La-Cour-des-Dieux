
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] sounds;
    private static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null){ instance = this; }
        else { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audio;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s==null)
        {
            Debug.LogError("Sound " + name + " not found !");
            return;
        }
        s.source.Play();
    }

    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogError("Sound " + name + " not found !");
            throw new Exception("This sound does not exist");
        }
        return s.source.isPlaying;
    }

    public void StopEverySounds()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }
}
