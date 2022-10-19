using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] basicEnemy;
    [SerializeField] private GameObject[] bossEnemy;
    [SerializeField] public GameObject[] enemySpawnPoints;
    [SerializeField] public GameObject[] bossSpawnPoint;
    private int waveNum = 0;
    private int levelNum = 0;
    private int numEnemies = 0;
    public int enemySpeed = 2;
    public int maxEnemies = 2;
    public bool waveComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        EnemySpawn();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //either changing wavechecker to a coroutine or checking if wavecomplete is true, setting it to false, and starting a new wave
        if (numEnemies <= 0)
        {
            waveComplete = true;
            waveNum++;
            maxEnemies++;
        }
        //else
        //{ EnemySpawn(); }
    }

    public void LevelChecker()
    {
        if(waveNum == 5)
        {
            levelNum++;
            waveNum = 0;
            maxEnemies = levelNum + 1;
        }
    }
    public void WaveManager()
    {
       
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
