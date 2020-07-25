using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class AnimationControllerTestImplementations : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sprite;
    public bool wineSurpaced;
    public Transform carryingTurretTransform,turretTransform;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        WalkingAnimationController();
        CarryTurretController();
        spriteController();
        if (wineSurpaced)
        {
            animator.SetTrigger("WineDrinking");
        }
    }
    private void WalkingAnimationController() 
    {
        if (Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical")!=0)
        {
            animator.SetBool("PlayerWalking", true);
        }
        else
        {
            animator.SetBool("PlayerWalking", false);

        }
    }
    private void CarryTurretController()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            turretTransform.parent = carryingTurretTransform.parent;
            turretTransform.rotation = carryingTurretTransform.rotation;
            animator.SetBool("Carrying", true);
            //turretTransform.localPosition = carryingTurretTransform.localPosition;
        }
        else if (Input.GetKey(KeyCode.LeftControl)&& Input.GetAxisRaw("Horizontal") < 0)
        {
            carryingTurretTransform.localPosition = new UnityEngine.Vector2(-carryingTurretTransform.localPosition.x, carryingTurretTransform.localPosition.y);

        }
        else
        {
            animator.SetBool("Carrying", false);
            turretTransform.rotation = new UnityEngine.Quaternion(0, 0, 0, 0);
        }
    }
    private void spriteController()
    {
        if (Input.GetAxisRaw("Horizontal") < 0)
        {  
            sprite.flipX=true;
        }
        else
        {
            sprite.flipX = false;

        }
    }
}
