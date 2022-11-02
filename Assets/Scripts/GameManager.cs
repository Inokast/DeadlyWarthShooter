using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//////////////////////////////////////////////
//Assignment/Lab/Project: Arcade Game
//Name: Daniel Sanchez, Steven Thompson, Talyn Epting
//Section: 2019SP.SGD.285.2144
//Instructor: Aurore Locklear
//Date: 10/12/2022
/////////////////////////////////////////////

public class GameManager : MonoBehaviour
{
    [Header("Basics")]
    public static GameManager gm;
    public bool paused, gameOver;
    int score;
    [SerializeField] int lives;
    GameObject player;

    public int Score
    {
        get { return score; }
        set 
        { 
            score = value;

            if (score < 0) { score = 0; }
        }
    }

    public int Lives
    {
        get { return lives; }
        set 
        { 
            lives = value;

            if (lives < 0) { lives = 0; }
        }
    }


    void Awake()
    {
        if(gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(gm);
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //Lives = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            PauseGame();
        }
    }

    void PauseGame()
    {
        if (paused == true)
        {
            Time.timeScale = 0f;
            //Debug.Log("Game is paused");
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void IncrementScore(int val)
    {
        Score += val;
    }

    public void IncrementLives()
    {
        Lives++;
    }

    public void DecrementLives()
    {
        player.SetActive(false);
        Lives--;
        if (Lives == 0)
        {
            gameOver = true;
        }
    }

    public IEnumerator GameOver(float overtime) 
    {
        while (true)
        {
            if (gameOver)
            {
                yield return new WaitForSeconds(overtime);
                gameOver = false;
            }
        }
    }

    public IEnumerator Restart()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
