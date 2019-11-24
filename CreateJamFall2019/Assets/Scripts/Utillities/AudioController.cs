using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public enum Sound {Test}
public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    
    private List<AudioSource> speakers = new List<AudioSource>();
    private Dictionary<string, AudioClip> clips;

    public static void Play(Sound sound)
    {
        Instance.PlaySound(sound);
    }
    
    private void Start()
    {
        LoadSounds();
        PlaySound(Sound.Test);
    }

    private void PlaySound(Sound sound)
    {
        var a = speakers[GetSpeaker()];
        a.clip = clips[sound.ToString()];
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
        speakers.Add(gameObject.AddComponent<AudioSource>());
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
