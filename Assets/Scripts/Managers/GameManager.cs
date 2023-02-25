using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables
    public static GameManager instance;

    public GameObject transitionGO;
    public AudioClip transitionClip;

    public int healthPlayer = 3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
        
        transitionGO.SetActive(false);
    }
    
    /// <summary>
    /// Method for changing the scene
    /// </summary>
    public void ChangeScene()
    {
        StartCoroutine(Coroutine_NextLevel());

        if (SceneManager.GetActiveScene().name == "SceneLevel_1")
        {
            UIManager.instance.bananaPoints = 0;
            
            SceneManager.LoadScene("SceneLevel_2");
        }
        else if (SceneManager.GetActiveScene().name == "SceneLevel_2")
        {
            UIManager.instance.bananaPoints = 0;

            SceneManager.LoadScene("SceneLevel_3");
        }
    }
    
    /// <summary>
    /// Coroutine for loading next scene
    /// </summary>
    /// <returns></returns>
    public IEnumerator Coroutine_NextLevel()
    {
        yield return new WaitForSeconds(30f);
    }
}
