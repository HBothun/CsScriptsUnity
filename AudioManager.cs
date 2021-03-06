using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;
    void Awake()
    {
          foreach(Sound s in sounds)
          {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.clip;

                s.source.volume = s.volume;
                s.source.pitch = s.pitch;
                s.source.loop = s.loop;
            

          }

    }
    

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        Play("Back Ground");
    }
}

