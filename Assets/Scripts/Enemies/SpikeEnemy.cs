using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeEnemy : MonoBehaviour
{
    // Variables
    [SerializeField] private int damage = 1;
    [SerializeField] private HealthManager healthManager;

    private void Awake()
    {
        // Getting the player healthManager
        healthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // If Player triggers with the spike, the spike takes damage to player
        if (other.gameObject.CompareTag("Player"))
        {
            healthManager.DecreaseHealth(damage);
        }
    }
}
