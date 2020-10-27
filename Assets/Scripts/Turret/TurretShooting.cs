﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

//TO-DO
//MAKE IT GENERAL
//EVERY OBJECT SHOULD HAVE THE RIGHT TO ARMS
public class TurretShooting : MonoBehaviour

{   
    private towerParameters tower;
    private float smallestDistance;
    [HideInInspector]
    public Collider2D enemyToShoot;
    private List<GameObject> boltsAtHand;
    [HideInInspector]
    private float timer;
    [HideInInspector]
    public Collider2D[] currentEnemiesInScene;
    //private moveTowerToPoint moveTowerToPoint;

    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<towerParameters>();
        smallestDistance = Mathf.Infinity;
        //moveTowerToPoint = GetComponent<moveTowerToPoint>();
    }

    // Update is called once per frame
    void Update()
    {

        //towerSeekNDestroy();



    }
    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        FindClosestEnemy();
        if (timer >= tower.reloadDelay&&enemyToShoot!=null)
        {
            shoot();
            timer = 0;
        }

    }


    //in order to chase and destroy coin add coin to the same layer as enemies
    private void FindClosestEnemy()
    { 
        enemyToShoot = null;
       currentEnemiesInScene=(Physics2D.OverlapCircleAll(transform.position, tower.radius, tower.enemieLayer));
       
        foreach (Collider2D enemyIndex in currentEnemiesInScene)
        {
            float distance = (transform.position - enemyIndex.transform.position).sqrMagnitude;
           
                if (smallestDistance > distance)
                {
                    smallestDistance = distance;
                    enemyToShoot = enemyIndex;
                    Debug.DrawLine(this.transform.position, enemyIndex.transform.position);
                }
            
            if (enemyToShoot == null)
            {
                smallestDistance = Mathf.Infinity;
            }
        }

    }
    public void shoot()
    {

        Instantiate(tower.boltPrefab, tower.transform.position, Quaternion.identity);
    }
    //private void towerSeekNDestroy()
    //{
    //    if (enemyToShoot != null && Vector2.Distance(transform.position,enemyToShoot.transform.position)>tower.towerReturnDistanceOffset)
    //    {
    //        //moveTowerToPoint.canTraverse = false;
    //        transform.position = Vector2.MoveTowards(transform.position, enemyToShoot.transform.position, tower.shootinSpeed);
    //    }
    //    //else
    //    //{
    //    //    moveTowerToPoint.canTraverse = true;
    //    //}
    //}
} 
