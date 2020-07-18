using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementWithWaypoints : MonoBehaviour
{

    //TO-DO
    //MOVE ΙΤ SOMEWHERE ELSE
    //MAYBE TO A MOVEMENT CONTROLLER


    private EnemyPaths enemyPathnWaypoints;
    [HideInInspector]
    public int pathIndex, waypointIndex;
    private SpawnManager spawnMng;
    private EnemyResetAndParameters enemyStats;
    private GameObject spawnManager;
    private Vector3 enemyObjectivePos;


    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.FindGameObjectWithTag("SpawnManager");
        enemyPathnWaypoints = spawnManager.GetComponent<EnemyPaths>();
        enemyStats = gameObject.GetComponent<EnemyResetAndParameters>();
        pathIndex = Random.Range(0, spawnManager.GetComponent<SpawnManager>().enemyPaths.Count);
        waypointIndex = 0;
        transform.position = enemyPathnWaypoints.enemyPaths[pathIndex].waypoints[waypointIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement();
    }
    public void enemyMovement()
    {
        enemyObjectivePos = enemyPathnWaypoints.enemyPaths[pathIndex].waypoints[waypointIndex].transform.position;
        this.transform.position = Vector3.MoveTowards(this.transform.position, enemyObjectivePos, enemyStats.speed* Time.deltaTime);
        if (this.gameObject.transform.position == enemyObjectivePos)
        {
            waypointIndex++;
        }
        if (waypointIndex >= enemyPathnWaypoints.enemyPaths[pathIndex].waypoints.Count)
        {
            Destroy(this.gameObject);
        }
    }
 
}
