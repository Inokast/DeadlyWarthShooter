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
    [SerializeField]private int levelNum = 1;
    private int bossNum = 0;
    public int numEnemies = 0;
    public int enemySpeed = 2;
    public int maxEnemies = 3;
    public bool waveComplete = false;
    public bool firstWave = true;
    public bool bossAlive = false;
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawn();
        waveNum = 1;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void LevelChecker()
    {
        if(waveNum == 4)
        {
            BossSpawn();
        }
        if(waveNum == 5)
        {
            levelNum++;
            
            maxEnemies = levelNum+ 1;
            waveNum = 1;
            //bossNum++;
        }
    }
    public void WaveManager()
    {
        if (numEnemies == 0)
        { EnemySpawn(); }

        
        
       
    }
    public void EnemyChecker()
    {
        if (numEnemies <= 0 && bossAlive == false)
        {
            Debug.Log("wave " + waveNum + " complete");
            // waveComplete = true;
            waveNum++;
            maxEnemies++;
           // Debug.Log("Max Enemies:" + maxEnemies);
            LevelChecker();
            EnemySpawn();


        }
    }

    public void EnemySpawn()
    {
        for(int i = 0; i < maxEnemies; i++)
        {
           Instantiate(basicEnemy[Random.Range(0, basicEnemy.Length)], enemySpawnPoints[i].transform);
            
            numEnemies++;
           // Debug.Log("Enemy" + i + "has been spawned");
            
        }
    }
    public void BossSpawn()
    {
       Instantiate(bossEnemy[0], bossSpawnPoint[0].transform);
        Debug.Log("The boss has spawned");
        bossAlive = true;
        numEnemies++;
        
    }
}
