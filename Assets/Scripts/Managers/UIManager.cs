using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Variables
    public static UIManager instance;
    
    [Header("PANELS")]
    [SerializeField] private List<GameObject> allPanels;

    [SerializeField] private GameObject mainMenuPnl;
    
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
        
        HideAllPanels();
        
        // Showing only the panel we want to display in awake
        mainMenuPnl.SetActive(true);
    }

    #region MAIN MENU INTERACTIONS

    /// <summary>
    /// Method for playing game when on click the Play_btn
    /// </summary>
    public void Play()
    {
        HideAllPanels();
        SceneManager.LoadScene("SceneLevel_1");
    }

    /// <summary>
    /// Method for quitting game when on click the QuitGame_btn
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    #endregion
    
    /// <summary>
    /// Method for hiding all panels
    /// </summary>
    public void HideAllPanels()
    {
        foreach (GameObject panel in allPanels)
        {
            panel.SetActive(false);
        }
    }
}
