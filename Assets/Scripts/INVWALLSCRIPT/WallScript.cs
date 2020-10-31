using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TO-DO
//THIS IS WRONG IN SO MANY WAYS
//RE-WRITE FOR CLEARER CONTEXT


public class WallScript : MonoBehaviour
{   [HideInInspector]
    public int currentWallHealth;
    public int maxWallHealth;
    private GameObject enemy;
    public Slider healthslider;
    // Start is called before the first frame update
    void Start()
    {
        healthslider.maxValue = maxWallHealth;
        currentWallHealth = 0;
    }

    // Update is called once per frame
    void Update()
    {
    
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.ToLower().Equals("enemy"))
        {
            currentWallHealth +=collision.gameObject.GetComponent<EnemyResetAndParameters>().damage;
            healthslider.value = currentWallHealth;
            Debug.Log(healthslider.maxValue);
        }
       
    }
}
