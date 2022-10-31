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
    [SerializeField] TextMeshProUGUI overText;
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject instructionsPanel;


    void Start()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;

        overText.text = "";
    }

    void Update()
    {
        ScoreUpdate();
        LivesUpdate();
        DisplayPause();

        if (GameManager.gm.gameOver)
        {
            overText.text = "Game Over";
            StartCoroutine(GameManager.gm.Restart());
        }
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
        menuPanel.SetActive(false);
        Debug.Log("Let the games begin");
        Time.timeScale = 1f;
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
            Debug.Log("Showing options");
        }
        else
        {
            optionsPanel.SetActive(false);
            Debug.Log("Options off");
        }
    }

    public void OnInstructionsClick()
    {
        if (instructionsPanel != null && !instructionsPanel.activeInHierarchy)
        {
            instructionsPanel.SetActive(true);
            Debug.Log("Showing help");
        }
        else
        {
            instructionsPanel.SetActive(false);
            Debug.Log("help off");
        }
    }

    public void OnQuitClick()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
    #endregion
}
