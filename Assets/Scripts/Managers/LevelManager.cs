using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Variables
    [SerializeField] private GameObject[] collectibles;
    [SerializeField] private HealthManager playerHealth;

    private void Awake()
    {
        // Calling the method for searching the collectibles on Scene
        SearchingCollectibles();
    }

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManager>();
        playerHealth.actualHealth = GameManager.instance.healthPlayer;
    }

    /// <summary>
    /// Method for getting the collectibles, putting on an array and changing the maxCollectibles num of UIManager
    /// </summary>
    public void SearchingCollectibles()
    {
        collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        
        UIManager.instance.maxCollectibles = collectibles.Length;
    }
}
