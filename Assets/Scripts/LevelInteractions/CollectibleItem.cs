using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    // Variables
    [SerializeField] private Animator anim;
    [SerializeField] private BoxCollider2D col;
    [SerializeField] private AudioClip clip;

    private void Awake()
    {
        // Getting the Animator
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If Player triggers, we increase the score, start the animation of collected and we play the corresponding sound
        if (other.gameObject.CompareTag("Player"))
        {
            UIManager.instance.IncreaseScore();
            col.enabled = false;

            anim.SetTrigger("Collected");
            AudioManager.instance.PlaySound(clip);
        }
    }

    /// <summary>
    /// Method for destroying the gameObject when the collected animation stops
    /// </summary>
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
