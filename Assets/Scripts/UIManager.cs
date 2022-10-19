using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Assignment/Lab/Project: Arcade Game
//Name: Talyn Epting

public class UIManager : MonoBehaviour
{
    [Header("Menus and HUD")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject optionsPanel;

    [Header("In-game Stats")]
    [SerializeField] TextMeshProUGUI playerHealth;
    [SerializeField] TextMeshProUGUI enemyHealth;       //temporary (most likely to be replaced by a collection? for when enemies are present)- T.E.


    void Start()
    {
        
    }

    void Update()
    {
        ScoreUpdate();
        LivesUpdate();
        DisplayPause();
    }

    void DisplayPause()
    {
        if (GameManager.gm.paused)
        {
            pausePanel.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(false);
        }
    }

    void ScoreUpdate()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {GameManager.gm.Score}";
        }
    }

    void LivesUpdate()
    {
        if (livesText != null)
        {
            livesText.text = $"Lives: {GameManager.gm.Lives}";
        }
    }

    #region buttons
    //to be added to/refined later- T.E.
    public void OnPlayClick()
    {
        GameManager.gm.gameStarted = true;
        menuPanel.SetActive(false);
        Debug.Log("Let the games begin");
    }

    public void OnMenuClick()
    {
        menuPanel.SetActive(true);
        GameManager.gm.paused = false;
        Debug.Log("Returned to menu");
    }

    public void OnOptionsClick()
    {
        if(optionsPanel != null && !optionsPanel.activeInHierarchy)
        {
            optionsPanel.SetActive(true);
            Debug.Log("Showing options/help");
        }
        else
        {
            optionsPanel.SetActive(false);
            Debug.Log("Options/help off");
        }
    }

    public void OnQuitClick()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
    #endregion
}
