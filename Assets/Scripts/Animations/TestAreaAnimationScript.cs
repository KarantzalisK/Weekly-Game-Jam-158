//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor.Animations;
//using UnityEngine;


//public class TestAreaAnimationScript : MonoBehaviour
//{
//    public Transform areaEdgeTransf;
//    public float respawnDelay;
//    private float timer=0;
//    private Animator animator;
//    private RuntimeAnimatorController animatorController;    
//    // Start is called before the first frame update
//    void Start()
//    {
//        animator = GetComponent<Animator>();
//        animatorController = animator.runtimeAnimatorController;
//        respawnDelay=animatorController.animationClips[0].length;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        timer += Time.deltaTime;
//        if (timer >= respawnDelay)
//        {
//            transform.position = new Vector2(Random.Range(-areaEdgeTransf.position.x, areaEdgeTransf.position.x), Random.Range(-areaEdgeTransf.position.y, areaEdgeTransf.position.y));
//            timer = 0;
//        }
//    }
  
//}
