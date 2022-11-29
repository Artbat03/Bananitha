using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Variables
    public static HealthBar instance;
    
    public Slider currentHealth;
    public HealthManager healthManager;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenuScene")
        {
            currentHealth.value = healthManager.initialHealth;
        }
    }
}
