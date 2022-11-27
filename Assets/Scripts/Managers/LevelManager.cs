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
        SearchingCollectibles();
    }

    public void SearchingCollectibles()
    {
        collectibles = GameObject.FindGameObjectsWithTag("Collectible");
        
        UIManager.instance.maxCollectibles = collectibles.Length;
    }
}
