using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Settings
    public float soundVolume;
    public float musicVolume;
    public GameManager gameManager;
    public Sound[] sounds;

    
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume + soundVolume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    void Update()
    {
        soundVolume = gameManager.playerSound;
        musicVolume = gameManager.playerMusic;
    }
}
