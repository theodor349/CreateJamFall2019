﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using Random = UnityEngine.Random;

public enum Sound {Test, Wood, Crate, Death, Vulcano, Crash, Mine, Jump, Shoot}
public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    
    private List<AudioSource> speakers = new List<AudioSource>();
    private Dictionary<string, AudioClip> clips;
    public AudioSource Music;
    public AudioClip BadMusic;

    public static void Play(Sound sound)
    {
        var s = sound.ToString();
        if (sound == Sound.Wood)
            s += ((int)Random.Range(1, 3)).ToString();
            
        Instance.PlaySound(s);
    }
    
    private void Start()
    {
        Instance = this;
        LoadSounds();
        EarthProperties.RegistreLevelUpAction(LevelUp);
    }

    private void LevelUp(int level)
    {
        if(level != 1)
            return;
        Music.clip = BadMusic;
        Music.Play();
    }

    private void PlaySound(string sound)
    {
        var a = speakers[GetSpeaker()];
        a.clip = clips[sound];

        if (sound.Equals(Sound.Death.ToString()) || sound.Equals(Sound.Jump.ToString()))
            a.pitch = Random.Range(0.8f, 2f);
        else
            a.pitch = 1;
        
        a.Play();
    }

    private int GetSpeaker()
    {
        for (int i = 0; i < speakers.Count; i++)
        {
            if (!speakers[i].isPlaying)
                return i;
        }
        
        return SpawnSpeaker();
    }

    private int SpawnSpeaker()
    {
        var s = gameObject.AddComponent<AudioSource>();
        s.spatialBlend = 0;
        s.volume = 0.2f;
        speakers.Add(s);
        return speakers.Count - 1;
    }

    private void LoadSounds()
    {
        clips = new Dictionary<string, AudioClip>();
        foreach (var clip in Resources.LoadAll("Sounds", typeof(AudioClip)))
        {
            clips.Add(clip.name, (AudioClip) clip);
        }
    }
}
