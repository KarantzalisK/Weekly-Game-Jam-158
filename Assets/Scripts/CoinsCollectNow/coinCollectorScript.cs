using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coinCollectorScript : MonoBehaviour
{

    //TO-DO 
    //MAKE THIS INTO COLLECTIBLE SPAWNER
    //MOVE UPGRADES TO UPGRADE MANAGER OR GAME MANAGER


    //public GameObject coinsGatheredTextobj;
    public int coinsToUpgrade=0,coinMultiplier;
    private int spawnLocsIndex;
    public GameObject coinsGatheredTextobj;
    [HideInInspector]
    public int coinsGathered = 0;
    public List<Transform> SpawnLocs;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinsGatheredTextobj.GetComponent<TMPro.TextMeshProUGUI>().text = coinsGathered.ToString() + "/" + coinsToUpgrade.ToString();
    }
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag =="collectible")
            {   
                CollectibleRectanglePosition(collision.gameObject);
            if (coinsGathered < coinsToUpgrade && coinsGathered<coinsToUpgrade- coinMultiplier)
            {
                coinsGathered = coinsGathered + coinMultiplier;
                
            }
            else coinsGathered = coinsToUpgrade;
        }
        Debug.Log("KOLAI");
    }
    private void CollectibleRectanglePosition(GameObject collectible) //respawns object to different position based to an imaginary rectanble by gettin an object at the edge of it
    {
        spawnLocsIndex = Random.Range(0, SpawnLocs.Count);
        if (SpawnLocs[spawnLocsIndex].transform.position != collectible.transform.position)
        {
            collectible.transform.position = SpawnLocs[spawnLocsIndex].transform.position;
        }
        

    }


}
