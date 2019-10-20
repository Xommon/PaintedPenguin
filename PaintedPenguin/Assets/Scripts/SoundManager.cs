using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Settings
    public float soundVolume;
    public float musicVolume;
    public GameManager gameManager;

    // Sounds
    public AudioClip powerUpSound;

    // Music

    
    void Start()
    {
        //powerUpSound
    }
    
    void Update()
    {
        soundVolume = gameManager.playerSound;
        musicVolume = gameManager.playerMusic;
    }
}
