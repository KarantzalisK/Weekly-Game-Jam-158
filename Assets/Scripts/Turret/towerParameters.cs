﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TO-DO
//THIS SHOULDN'T BE A SEPERATE SCRIPT
public class towerParameters : MonoBehaviour
{
    //public GameObject arrow;
    public int towerDMG;
    public float reloadDelay,shootinSpeed,radius,boltSpeed,boltdmg;
    public float turretRespawnDelay;
    public GameObject boltPrefab;
    public float boltLifeSpam;
    public LayerMask enemieLayer;
    public float towerReturnDistanceOffset;
    [HideInInspector]
    public bool canShoot;
    // Start is called before the first frame update
    void Start()
    {
     


    }

    // Update is called once per frame
    void Update()
    {
    }
 
   
  
 
}
