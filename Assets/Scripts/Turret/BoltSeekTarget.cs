using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TO-DO
//RENAME SCRIPT
public class BoltSeekTarget : MonoBehaviour
{
    private towerParameters tower;
    private TurretShooting turretShooting;
    private Vector3 targetToKill;
    private Transform boltTransf;
    private float boltLifeSpam;
    private float boltdmg,boltSpeed;
    // Start is called before the first frame update
    //placed at bolt preab
    void Start()
    {
        tower= GameObject.FindObjectOfType<towerParameters>().GetComponent<towerParameters>();
        turretShooting = tower.GetComponent<TurretShooting>();
        targetToKill = turretShooting.enemyToShoot.gameObject.transform.position;
        boltTransf = this.transform;
        boltLifeSpam = tower.boltLifeSpam;
        boltdmg = tower.boltdmg;
        StartCoroutine(waitToDestroy());
        boltSpeed = tower.boltSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        boltTransf.position = Vector2.MoveTowards(boltTransf.position,targetToKill, boltSpeed * Time.deltaTime);
        if (targetToKill == null)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //StartCoroutine(waitToDestroy());
        if (collision.CompareTag("enemy"))
        {
           collision.GetComponent<EnemyResetAndParameters>().currentHealth += boltdmg;
            Destroy(this.gameObject);
        }
        
        
       
    }
    IEnumerator waitToDestroy()
    {
        yield return new WaitForSeconds(boltLifeSpam);
        Destroy(this.gameObject);
    }

}
