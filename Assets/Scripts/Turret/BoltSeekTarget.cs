using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TO-DO
//RENAME SCRIPT
public class BoltSeekTarget : MonoBehaviour
{   
    [HideInInspector]
    public towerParameters towerParameters=null;
    [HideInInspector]
    private TurretShooting turretShooting;
    [HideInInspector]
    public Vector3 targetToKill;
    private Transform boltTransf;
    private float boltLifeSpam;
    private float boltdmg,boltSpeed;
 
    // Start is called before the first frame update
    //placed at bolt preab
    void Start()
    {
        turretShooting = towerParameters.GetComponent<TurretShooting>();
        targetToKill = turretShooting.enemyToShoot.gameObject.transform.position;
        boltTransf = this.transform;
        boltSpeed = towerParameters.boltSpeed;
        boltLifeSpam = towerParameters.boltLifeSpam;
        boltdmg = towerParameters.boltdmg;
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
