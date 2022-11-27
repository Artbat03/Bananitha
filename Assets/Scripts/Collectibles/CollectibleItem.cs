using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    // Variables
    [SerializeField] private Animator anim;
    [SerializeField] private AudioClip clip;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIManager.instance.IncreaseScore();
            anim.SetTrigger("Collected");
            AudioManager.instance.PlaySound(clip);
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
