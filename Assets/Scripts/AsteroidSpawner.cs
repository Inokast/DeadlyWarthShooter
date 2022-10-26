using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] asteroids;
    [SerializeField] float spawnTime;


    void Start()
    {
        StartCoroutine(DoSpawnAsteroid());
    }

    void Update()
    {
        
    }

    IEnumerator DoSpawnAsteroid()
    {
        yield return new WaitForSeconds(spawnTime);
        
    }
}
