using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    // Variables
    [Header("AUDIOCLIP")]
    [SerializeField] private AudioClip _clip;

    private void Start()
    {
        // Calling the method PlaySound of AudioManager for reproduce the sound we pass in param in start
        // For example, when we spawn an object
        AudioManager.instance.PlaySound(_clip);
    }
}
