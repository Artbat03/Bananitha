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
        AudioManager.instance.PlaySound(_clip);
    }
}
