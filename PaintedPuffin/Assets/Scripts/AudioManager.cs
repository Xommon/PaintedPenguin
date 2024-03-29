﻿using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public GameManager gameManager;
    public AudioMixerGroup mixerGroup;
    public Sound[] sounds;
    public Sound so;

    public bool fadeOut;
    public bool fadeIn;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.outputAudioMixerGroup = mixerGroup;
        }
    }

    public void Play(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        if (s.music == true)
        {
            s.source.volume = FindObjectOfType<GameManager>().playerMusic;
            s.source.loop = true;
        }
        else
        {
            s.source.volume = FindObjectOfType<GameManager>().playerSound;
            s.source.loop = false;
        }

        s.source.Play();
    }

    public void Pause()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            string sound = sounds[i].name;

            Sound s = Array.Find(sounds, item => item.name == sound);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            if (s.music == false)
            {
                s.source.Pause();
            }
            else
            {
                s.volume /= 2;
            }
        }
    }

    public void Pause(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Pause();
    }

    public void Unpause()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            string sound = sounds[i].name;

            Sound s = Array.Find(sounds, item => item.name == sound);
            if (s == null)
            {
                Debug.LogWarning("Sound: " + name + " not found!");
                return;
            }

            if (s.music == false)
            {
                s.source.UnPause();
            }
            else
            {
                s.volume *= 2;
            }
        }
    }

    public void Unpause(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.UnPause();
    }

    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();
    }

    public void FadeOut(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        fadeOut = true;
        so = s;
    }

    public void FadeIn(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        Play(s.name);
        s.volume = 0;
        fadeIn = true;
        so = s;
    }

    private void FixedUpdate()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
    }

    private void Update()
    {
        if (fadeOut == true)
        {
            if (so.source.volume > 0)
            {
                so.source.volume -= (gameManager.playerMusic / 50);
            }
            else
            {
                Stop(so.name);
                fadeOut = false;
            }
        }
        else if (fadeIn == true)
        {
            if (so.source.volume < gameManager.playerMusic)
            {
                so.source.volume += (gameManager.playerMusic / 50);
            }
            else
            {
                fadeIn = false;
                so.source.volume = gameManager.playerMusic;
            }
        }
        else
        {
            if (gameManager.paused)
            {
                for (int i = 0; i < sounds.Length; i++)
                {
                    string sound = sounds[i].name;

                    Sound s = Array.Find(sounds, item => item.name == sound);
                    if (s == null)
                    {
                        Debug.LogWarning("Sound: " + name + " not found!");
                        return;
                    }

                    if (s.music == true)
                    {
                        s.source.volume = (gameManager.playerMusic / 4);
                    }
                }
            }
            else
            {
                for (int i = 0; i < sounds.Length; i++)
                {
                    string sound = sounds[i].name;

                    Sound s = Array.Find(sounds, item => item.name == sound);
                    if (s == null)
                    {
                        Debug.LogWarning("Sound: " + name + " not found!");
                        return;
                    }

                    if (s.music == true)
                    {
                        s.source.volume = gameManager.playerMusic;
                    }
                }
            }
        }
    }
}
