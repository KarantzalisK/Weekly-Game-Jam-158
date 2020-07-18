using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;


//TO-DO
//REWRITE ENEMY SELECTOR
//INCLUDE PARAMETERS

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    public List<EnemyPaths> enemyPaths;

    [SerializeField]
    public List<EnemyWavesParameters> activeWave;
    [HideInInspector]
    public float timeCounter, instanciateDelay;
    [HideInInspector]
    public bool canSpawn = true;
    [HideInInspector]
    public int i = 0, amountOfEnemies = 0, waveNumber = 0,amountOfEasiestEnemy;
    private int  enemyIndexer;
    public GameObject[] enemyPrefabs;


    void Start()
    {
        waveNumber = 0;
    }

    void Update()
    {
        if (waveNumber < activeWave.Count)
        {
            amountOfEasiestEnemy = activeWave[waveNumber].amountOfFirstEnemyType;
            amountOfEnemies = activeWave[waveNumber].maxEnemies;
            instanciateDelay = activeWave[waveNumber].enemySpawningRate;

            timeCounter += Time.deltaTime;
            if (canSpawn)
            {
                enemySelector();
                enemyInstantiateCheck();
            }
        }
        else {
            ///Game Finished
            Debug.Log("Finished Final Wave Of This Level");
        }

    }
    private void enemyInstantiateCheck()
    {

        if (i < amountOfEnemies)
        {  
            if (timeCounter >= instanciateDelay)
            {
                
                timeCounter = 0;
                i++;
                enemyInstantiatNaddToList();


            }

        }

        else
        {
            canSpawn = false;

        }
    }
    private void enemyInstantiatNaddToList()
    {
       activeWave[waveNumber].currentEnemies.Add(Instantiate(enemyPrefabs[enemyIndexer], gameObject.transform.position, Quaternion.identity));
    }
    private void enemySelector()
    {
        if (i < amountOfEasiestEnemy)
        {
            enemyIndexer = 0;
        }
         if (i>amountOfEasiestEnemy && i <= amountOfEnemies)
        {
            enemyIndexer = UnityEngine.Random.Range(1,enemyPrefabs.Length);
        }
    }

}


