using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public float soundVolume;
    public float musicVolume;
    public GameManager gameManager;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        soundVolume = gameManager.playerSound;
        musicVolume = gameManager.playerMusic;
    }
}
