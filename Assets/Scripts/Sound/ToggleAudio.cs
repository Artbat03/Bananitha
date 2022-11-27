using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ToggleAudio : MonoBehaviour
{
    // Variables
    [Header("TOGGLE BOOLS")]
    [SerializeField] private bool _toggleMusic;
    [SerializeField] private bool _toggleEffects;

    [Space(15)] 
    [Header("UNCHECKMARK IMAGE")]
    [SerializeField] private GameObject uncheckMark;

    public void Toggle()
    {
        if (_toggleMusic)
        {
            AudioManager.instance.ToggleMusic();

            if (GetComponent<Toggle>().isOn)
            {
                uncheckMark.SetActive(false);
            }
            else
            {
                uncheckMark.SetActive(true);
            }
        }
        else if (_toggleEffects)
        {
            AudioManager.instance.ToggleEffects();
            
            if (GetComponent<Toggle>().isOn)
            {
                uncheckMark.SetActive(false);
            }
            else
            {
                uncheckMark.SetActive(true);
            }
        }
    }
}
