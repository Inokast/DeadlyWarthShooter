using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Assignment/Lab/Project: Arcade Game
//Name: Talyn Epting

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnObject;
    [SerializeField] float generationTime;


    void Start()
    {
        StartCoroutine(GenerateSpawnObject(generationTime));
    }

    IEnumerator GenerateSpawnObject(float genTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(genTime);

            foreach (GameObject spawn in spawnObject)
            {
                Instantiate(spawn, gameObject.transform.position, Quaternion.identity);
            }
        }
    }
}
