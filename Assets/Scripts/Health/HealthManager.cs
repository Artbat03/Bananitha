using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    // Variables
    [Header("HEALTH PARAMS")]
    public int initialHealth;
    public int actualHealth;
    
    [Space (15)]
    [Header("AUDIO CLIP")]
    [SerializeField] private AudioClip deathSFX;

    private void Awake()
    {
        // Setting the default values
        initialHealth = 3;
        actualHealth = initialHealth;
    }

    public void DecreaseHealth(int value)
    {
        actualHealth -= value;
        HealthBar.instance.currentHealth.value = actualHealth;

        if (actualHealth == 0)
        {
            // Reset bananaPoints and health
            UIManager.instance.bananaPoints = 0;
            HealthBar.instance.currentHealth.value = initialHealth;
            
            // Play death sound
            AudioManager.instance.PlaySound(deathSFX);

            // Reloading the active scene
            StartCoroutine(Coroutine_Death());
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public IEnumerator Coroutine_Death()
    {
        yield return new WaitForSeconds(10f);
    }
}
