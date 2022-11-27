using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    // Variables
    [SerializeField] private Slider _slider;

    private void Start()
    {
        AudioManager.instance.ChangeMasterVolume(_slider.value);
        _slider.onValueChanged.AddListener(val => AudioManager.instance.ChangeMasterVolume(val));
    }
}
