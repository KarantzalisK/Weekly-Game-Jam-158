using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowards4SceneCritters : MonoBehaviour
{
    public int speed,xOffset;
    private Vector2 initialPos;
    
    // Start is called before the first frame update
    void Start()
    {
        initialPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position!=new Vector3(Mathf.Abs(initialPos.x)+xOffset, initialPos.y,0))
        {
            LivelyCritter();
        }
    }
    private void LivelyCritter()
    {
        gameObject.transform.position = Vector2.MoveTowards(initialPos, new Vector2(Mathf.Abs(initialPos.x)+xOffset, initialPos.y), speed*Time.deltaTime);

    }
}
