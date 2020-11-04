using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TO-DO
//THIS SHOULDN'T BE ON A SEPERATE SCRIPT

public class EnemyWavesParameters : MonoBehaviour
{
    //[HideInInspector]
    //[HideInInspector]
    public int maxEnemies=0 ;
    public int nextWaveStartDelay;
    public int numberOfEnemyTypes,DebugInt;
    public float enemySpawningRate;
    //[HideInInspector]
    public List<GameObject> currentEnemies;
    public GameObject spawnManager;
    public List<int> enemiesInThisRound;
    

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager");
       
        for (int i = 0; i < enemiesInThisRound.Count; i++)
        {
            maxEnemies = maxEnemies + enemiesInThisRound[i];
          
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentEnemies.Count == maxEnemies)
        {
            StartCoroutine(waveChangeDelay());
            spawnManager.GetComponent<uIscripts>().winningPannelActivate = true;

        }     
    }
    IEnumerator waveChangeDelay()
    {
        int existingEnemiesCounter=0;
        
        foreach (GameObject actvEnm in currentEnemies)
        {
            if (actvEnm== null)
            {
                existingEnemiesCounter++;
            }
        }
        if (existingEnemiesCounter >= maxEnemies)
        {
            currentEnemies.Clear();
            yield return new WaitForSeconds(nextWaveStartDelay);
            spawnManager.GetComponent<SpawnManager>().waveNumber++;
            spawnManager.GetComponent<SpawnManager>().canSpawn = true;
            spawnManager.GetComponent<SpawnManager>().i = 0;
            spawnManager.GetComponent<SpawnManager>().enemyIndexer=0;
             existingEnemiesCounter = 0;
        }
        }
  
}
