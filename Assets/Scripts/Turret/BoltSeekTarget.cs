using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TO-DO
//RENAME SCRIPT
public class BoltSeekTarget : MonoBehaviour
{   
    [HideInInspector]
    public List<towerParameters> towerParameters;
    [HideInInspector]
    public GameObject[] tower;
    [HideInInspector]
    public TurretShooting turretShooting;
    [HideInInspector]
    public Vector3 targetToKill;
    public Transform boltTransf;
    public float boltLifeSpam;
    public float boltdmg,boltSpeed;
    [HideInInspector]
    public int towerIndex=0;
    // Start is called before the first frame update
    //placed at bolt preab
    void Start()
    {
        //tower= GameObject.FindGameObjectsWithTag("");
        tower = GameObject.FindGameObjectsWithTag("turret");        
        turretShooting = tower[towerIndex].GetComponent<TurretShooting>();
        targetToKill = turretShooting.enemyToShoot.gameObject.transform.position;
        boltTransf = this.transform;
        StartCoroutine(waitToDestroy());
    }

    // Update is called once per frame
    void Update()
    {
        boltTransf.position = Vector2.MoveTowards(boltTransf.position,targetToKill, boltSpeed * Time.deltaTime);
        if (targetToKill == null)
        {
            //Destroy(this.gameObject); katastrefete apo to animation script
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //StartCoroutine(waitToDestroy());
        if (collision.CompareTag("enemy"))
        {
           collision.GetComponent<EnemyResetAndParameters>().currentHealth += boltdmg;
            //Destroy(this.gameObject);
        }
        
        
       
    }
    IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(boltLifeSpam);
        Destroy(this.gameObject);
    }

}
