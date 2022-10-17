using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject basicEnemy;
    [SerializeField] private GameObject bossEnemy;
    [SerializeField] public GameObject enemySpawnPoints;
    [SerializeField] public GameObject bossSpawnPoint;
    private int waveNum = 0;
    private int levelNum = 0;
    private int numEnemies = 0;
    public int enemySpeed = 2;
    public int maxEnemies = 2;
    public bool waveComplete = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //either changing wavechecker to a coroutine or checking if wavecomplete is true, setting it to false, and starting a new wave
    }

    public void LevelChecker()
    {
        
    }
    public void WaveChecker()
    {
        if(numEnemies == 0)
        {
            waveComplete = true;
            waveNum++;
        }
    }

    public void EnemySpawn()
    {

    }
    
}
