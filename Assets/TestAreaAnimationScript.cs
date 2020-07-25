using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestAreaAnimationScript : MonoBehaviour
{
    public Transform areaEdgeTransf;
    public float respawnDelay;
    private float timer=0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Random.Range(timer/2,timer) >= respawnDelay)
        {
            transform.position = new Vector2(Random.Range(-areaEdgeTransf.position.x, areaEdgeTransf.position.x), Random.Range(-areaEdgeTransf.position.y, areaEdgeTransf.position.y));
            timer = 0;
        }
    }
  
}
