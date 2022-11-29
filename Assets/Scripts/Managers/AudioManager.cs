using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    // Variables
    public static AudioManager instance;

    [Header("AUDIO SOURCES")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _effectsSource;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    /// <summary>
    /// Method for playing the sound effect only one shot
    /// </summary>
    /// <param name="clip">The clip to play</param>
    public void PlaySound(AudioClip clip)
    {
        _effectsSource.PlayOneShot(clip);
    }
    
    /// <summary>
    /// Method for playing the sound effect only one shot
    /// </summary>
    /// <param name="clip">The clip to play</param>
    public void StopSound()
    {
        _effectsSource.Stop();
    }

    /// <summary>
    /// Method for mute and unmute the music game
    /// </summary>
    public void ToggleMusic()
    {
        _musicSource.mute = !_musicSource.mute;
    }

    /// <summary>
    /// Method for mute and unmute the SFX sounds
    /// </summary>
    public void ToggleEffects()
    {
        _effectsSource.mute = !_effectsSource.mute;
    }
}
