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
    [SerializeField] private BoxCollider2D col;

    private void Awake()
    {
        // Getting the animator
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If Player triggers de checkpoint and bananaPoints is equal to max possible collectibles, loads the next scene
        // If the last scene is Level 3, only show a panel in UI for restarting game, going to main menu or quitting game
        if (other.gameObject.CompareTag("Player"))
        {
            if (UIManager.instance.bananaPoints == UIManager.instance.maxCollectibles)
            {
                col.enabled = false;
                
                anim.SetTrigger("AllCollected");
                AudioManager.instance.PlaySound(checkpointSFX);
            }
        }
    }
    
    /// <summary>
    /// Method for activating the transition gameObject
    /// </summary>
    public void ChangeScene()
    {
        if (SceneManager.GetActiveScene().name != "SceneLevel_3")
        {
            GameManager.instance.transitionGO.SetActive(true);

            AudioManager.instance.PlaySound(GameManager.instance.transitionClip);
        } 
        
        if (SceneManager.GetActiveScene().name == "SceneLevel_3")
        {
            UIManager.instance.bananaPoints = 0;

            // Hiding all panels
            UIManager.instance.HideAllPanels();
            
            // Show the panel I want
            UIManager.instance.winPnl.SetActive(true);
            
            HealthBar.instance.currentHealth.value = 3;
        }
    }
}
