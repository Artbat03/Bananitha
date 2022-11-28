using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    // Variables
    public static UIManager instance;
    
    [Header("PANELS")]
    [SerializeField] private List<GameObject> allPanels;

    [SerializeField] public GameObject mainMenuPnl; // Change to private
    [SerializeField] private GameObject inGamePnl;

    [Space(15)]
    [Header("BUTTONS")]
    [SerializeField] private AudioClip _clip;
    [SerializeField] private GameObject _homeBtn;
    
    [Space (15)]
    [Header("COLLECTIBLES PARAMS")]
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

        // Hiding all panels just in case we have displayed an incorrect
        HideAllPanels();

        // Showing only the panel we want to display in awake
        mainMenuPnl.SetActive(true);
    }

    private void Update()
    {
        UpdateCollectiblesNum();
        
        if (SceneManager.GetActiveScene().name == "MainMenuScene")
        {
            StartCoroutine(Coroutine_HideShowHome());
            _homeBtn.SetActive(false);
            return;
        }
        
        if (SceneManager.GetActiveScene().name != "MainMenuScene")
        {
            StartCoroutine(Coroutine_HideShowHome());
            _homeBtn.SetActive(true);
            return;
        }
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

    /// <summary>
    /// Method for going to main menu on click the Home_btn
    /// </summary>
    public void MainMenu()
    {
        if (SceneManager.GetActiveScene().name != "MainMenuScene")
        {
            //AudioManager.instance.PlaySound(_clip);

            HideAllPanels();
            bananaPoints = 0;
            SceneManager.LoadScene("MainMenuScene");
            mainMenuPnl.SetActive(true);
        }
    }
    
    /// <summary>
    /// Method for increasing the score
    /// </summary>
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

    public IEnumerator Coroutine_HideShowHome()
    {
        yield return new WaitForSeconds(10f);
    }
}
