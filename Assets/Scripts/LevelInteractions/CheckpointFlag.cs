using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointFlag : MonoBehaviour
{
    // Variables
    [SerializeField] private Animator anim;
    [SerializeField] private AudioClip checkpointSFX;

    private void Awake()
    {
        // Getting the animator
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If Player triggers de checkpoint and bananaPoints is equal to max possible collectibles, loads the next scene
        // If the last scene is Level 3, only show a panel in UI for restarting game, going to main menu or quitting game
        if (other.gameObject.CompareTag("Player"))
        {
            if (UIManager.instance.bananaPoints == UIManager.instance.maxCollectibles)
            {
                anim.SetTrigger("AllCollected");
                AudioManager.instance.PlaySound(checkpointSFX);
            }
        }
    }
    
    public void ChangeScene()
    {
        StartCoroutine(Coroutine_NextLevel());
        
        if (SceneManager.GetActiveScene().name == "SceneLevel_1")
        {
            SceneManager.LoadScene("MainMenuScene");
            UIManager.instance.bananaPoints = 0;
            
            // Delete this lines before
            UIManager.instance.HideAllPanels();
            UIManager.instance.mainMenuPnl.SetActive(true);
            HealthBar.instance.currentHealth.value = 3;

            // SceneManager.LoadScene("SceneLevel_2");
        }/*
        else if (SceneManager.GetActiveScene().name == "SceneLevel_2")
        {
            SceneManager.LoadScene("SceneLevel_3");
        }
        else if (SceneManager.GetActiveScene().name == "SceneLevel_3")
        {
            Time.timeScale = 0;

            UIManager.instance.HideAllPanels();
            
            // Show the panel I want
            UIManager.instance.winPnl.SetActive(true);
            HealthBar.instance.currentHealth.value = 3;
        }*/
    }

    /// <summary>
    /// Coroutine for loading next scene
    /// </summary>
    /// <returns></returns>
    public IEnumerator Coroutine_NextLevel()
    {
        yield return new WaitForSeconds(5f);
    }
}
