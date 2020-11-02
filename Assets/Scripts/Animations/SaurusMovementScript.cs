﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaurusMovementScript : MonoBehaviour
{
    public int locationIndex;
    private Vector2 lizardLoc;
    public List<Transform> locations;
    public int speed;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        lizardLoc = transform.position;
        locationSwitcher();
        lookOriantation();

    }
    private void locationSwitcher()
    {
        transform.position = Vector2.MoveTowards(transform.position, locations[locationIndex].position, speed*Time.deltaTime);
        if (transform.position.x>= locations[locationIndex].position.x + offset)
        {
            locationIndex = Random.Range(0, locations.Count - 1);
        }
        if (locationIndex == locations.Count - 1)
        {
            locationIndex = 0;
        }

    }
    private void lookOriantation()
    {
        float angle;
        if (transform.position.x < locations[locationIndex].position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    else
        {
            GetComponent<SpriteRenderer>().flipX = false;

        }
        angle = Mathf.Atan2(locations[locationIndex].position.y - lizardLoc.y, locations[locationIndex].position.x - lizardLoc.x);
        transform.rotation =Quaternion.AngleAxis(angle,Vector3.forward) ;
    }
}
