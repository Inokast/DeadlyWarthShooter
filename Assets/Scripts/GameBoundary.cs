using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assignment/Lab/Project: Arcade Game
//Name: Talyn Epting

public class GameBoundary : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] GameObject[] asteroid;
    [SerializeField] float[] bounds;        //in order: left, right, up, down
    [SerializeField] float offset = .1f;


    void Start()
    {
        asteroid = GameObject.FindGameObjectsWithTag("Asteroid");
    }

    void Update()
    {
        PlayerBoundsCheck();

        try 
        {
            if (asteroid != null)
            {
                AsteroidBoundsCheck();
            }
        }
        catch { Debug.Log("Error in bounds check for asteroid") ; }
    }

    void PlayerBoundsCheck()
    {
        if (player.position.x < bounds[0])    //left bound
        {
            float newXPos = player.position.x * -1 - offset;
            player.position = new Vector2(newXPos, player.position.y);
        }

        if (player.position.x > bounds[1])    //right bound
        {
            float newXPos = player.position.x * -1 + offset;
            player.position = new Vector2(newXPos, player.position.y);
        }

        if (player.position.y > bounds[2])    //top bound
        {
            float newYPos = player.position.y * -1 + offset;
            player.position = new Vector2(player.position.x, newYPos);
        }

        if (player.position.y < bounds[3])    //bottom bound
        {
            float newYPos = player.position.y * -1 - offset;
            player.position = new Vector2(player.position.x, newYPos);
        }
    }

    void AsteroidBoundsCheck()
    {
        foreach(GameObject a in asteroid)
        {
            if (a.transform.position.x < bounds[0])    //left bound
            {
                float newXPos = a.transform.position.x * -1 - offset;
                a.transform.position = new Vector2(newXPos, player.position.y);
            }

            if (a.transform.position.x > bounds[1])    //right bound
            {
                float newXPos = a.transform.position.x * -1 + offset;
                a.transform.position = new Vector2(newXPos, player.position.y);
            }

            if (a.transform.position.y > bounds[2])    //top bound
            {
                float newYPos = a.transform.position.y * -1 + offset;
                a.transform.position = new Vector2(player.position.x, newYPos);
            }

            if (a.transform.position.y < bounds[3])    //bottom bound
            {
                float newYPos = a.transform.position.y * -1 - offset;
                a.transform.position = new Vector2(player.position.x, newYPos);
            }
        }
    }
}
