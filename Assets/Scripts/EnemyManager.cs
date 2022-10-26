using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//Assignment: Arcade Game
//Name: Steven Thompson
public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] basicEnemy;
    [SerializeField] private GameObject[] bossEnemy;
    [SerializeField] public GameObject[] enemySpawnPoints;
    [SerializeField] public GameObject[] bossSpawnPoint;
    [SerializeField]public int waveNum = 1;
    private int levelNum = 1;
    public int numEnemies = 0;
    public int enemySpeed = 2;
    public int maxEnemies = 3;
    public bool waveComplete = false;
    public bool firstWave = true;
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawn();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void LevelChecker()
    {
        if(waveNum == 4)
        {
            levelNum++;
            waveNum = 1;
            maxEnemies = levelNum++;
        }
    }
    public void WaveManager()
    {
        if (numEnemies == 0)
        { EnemySpawn(); }

        
        
       
    }
    public void EnemyChecker()
    {
        if (numEnemies <= 0)
        {
            Debug.Log("wave " + waveNum + " complete");
            // waveComplete = true;
            waveNum++;
            maxEnemies++;
            Debug.Log("Max Enemies:" + maxEnemies);
            LevelChecker();
            EnemySpawn();


        }
    }

    public void EnemySpawn()
    {
        for(int i = 0; i < maxEnemies; i++)
        {
           Instantiate(basicEnemy[Random.Range(0, basicEnemy.Length)], enemySpawnPoints[Random.Range(0,enemySpawnPoints.Length)].transform);
            
            numEnemies++;
            Debug.Log("Enemy" + i + "has been spawned");
            
        }
    }
    public void BossSpawn()
    {
       GameObject currentBoss = Instantiate(bossEnemy[waveNum], bossSpawnPoint[0].transform);
        Debug.Log("The boss has spawned");
    }
}
