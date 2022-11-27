using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Variables
    public static UIManager instance;
    
    [Header("PANELS")]
    [SerializeField] private List<GameObject> allPanels;

    [SerializeField] private GameObject mainMenuPnl;
    [SerializeField] private GameObject inGamePnl;

    [SerializeField] private TextMeshProUGUI collectiblesTxt;
    public int bananaPoints;
    public int maxCollectibles;

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

    private void Update()
    {
        UpdateCollectiblesNum();
    }

    #region MAIN MENU INTERACTIONS

    /// <summary>
    /// Method for playing game when on click the Play_btn
    /// </summary>
    public void Play()
    {
        HideAllPanels();
        SceneManager.LoadScene("SceneLevel_1");
        inGamePnl.SetActive(true);
    }

    /// <summary>
    /// Method for quitting game when on click the QuitGame_btn
    /// </summary>
    public void Quit()
    {
        Application.Quit();
    }

    #endregion

    #region IN GAME INTERACTIONS

    public void IncreaseScore()
    {
        bananaPoints++;
        UpdateCollectiblesNum();
    }
    
    /// <summary>
    /// Method for updating the UI
    /// </summary>
    public void UpdateCollectiblesNum()
    {
        collectiblesTxt.text = bananaPoints + "/" + maxCollectibles;
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
