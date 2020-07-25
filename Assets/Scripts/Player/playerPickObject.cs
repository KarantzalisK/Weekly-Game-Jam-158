﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TO-DO 
//MAKE IT GENERAL
//EXECUTE BY ANY OBJECT

public class playerPickObject : MonoBehaviour
{
   
    private Transform newTurretPosition;
    private Transform objTransf;
    private GameObject turret;
    private PlayerParameters player;

    // Start is called before the first frame update
    void Start()
    {
        turret = GameObject.FindGameObjectWithTag("turret");
        player = GetComponent<PlayerParameters>();
        objTransf = turret.GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        newTurretPosition = player.newTurretPosition;
        //objTransf = turret.transform;
        PickUpObj();

    }
    private void PickUpObj()
    {
        if (Input.GetKeyDown(KeyCode.Space) && player.canCarry)
        {
           player.carrying = true;
            player.holdingObject = true;
            //turret.GetComponent<moveTowerToPoint>().canTraverse = false;



        }
        if (Input.GetKeyUp(KeyCode.Space))
        {

            player.carrying = false;
            player.holdingObject = false;
            //turret.GetComponent<moveTowerToPoint>().canTraverse = true;


        }

        if (player.carrying)
        {
            objTransf.position = newTurretPosition.position;


        }
        else
        {
            player.carrying = false;
            player.holdingObject = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "turret")
        {
            player.canCarry = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "turret")
        {
            player.canCarry = false;
        }
    }
}
