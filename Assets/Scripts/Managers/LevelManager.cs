using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Variables
    [SerializeField] private GameObject[] collectibles;

    private void Awake()
    {
        // Calling the method for searching the collectibles on Scene
        SearchingCollectibles();
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
