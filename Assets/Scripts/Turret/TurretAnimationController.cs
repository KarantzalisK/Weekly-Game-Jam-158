using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAnimationController : MonoBehaviour
{
    private moveTowerToPoint towerToPointScript;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        towerToPointScript = GetComponent<moveTowerToPoint>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animationConroller();
    }
    private void animationConroller()
    {
        if (towerToPointScript.canTraverse)
        {
            animator.SetBool("CanWalk", true);
        }
        else
        {
            animator.SetBool("CanWalk", false);
        }
    }
}
