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
    public Transform carryingTurretTransform;
    private PlayerParameters playerParameters;
    private Transform turretTransform;
    private int animatorParametersCount=0;
    public List<string> animationParametersNames;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        playerParameters = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerParameters>();
        turretTransform = GameObject.FindGameObjectWithTag("turret").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        WalkingAnimationController();
        //CarryTurretController();
        spriteController();
        checkIfAnimationIsPlayed();
        ShowParametersNamesAtInspector();
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
    //private void CarryTurretController()
    //{
    //    if (Input.GetKey(KeyCode.Space)&&playerParameters.canCarry)
    //    {
    //        turretTransform.parent = carryingTurretTransform.parent;
    //        turretTransform.rotation = carryingTurretTransform.rotation;
    //        animator.SetBool("Carrying", true);
    //        //turretTransform.localPosition = carryingTurretTransform.localPosition;
    //    }
    //    else if (Input.GetKey(KeyCode.Space) && Input.GetAxisRaw("Horizontal") < 0)
    //    {
    //        carryingTurretTransform.localPosition = new UnityEngine.Vector2(-carryingTurretTransform.localPosition.x, carryingTurretTransform.localPosition.y);

    //    }
    //    else
    //    {
    //        animator.SetBool("Carrying", false);
    //        turretTransform.parent = null;
    //        turretTransform.rotation = new UnityEngine.Quaternion(0, 0, 0, 0);
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("collectible"))
        {
            animator.Play("PickUpCollectibleAnim", 0);
            animator.SetBool("collidedWithCoin", true);

        }
    }
    private void checkIfAnimationIsPlayed()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("PickUpCollectibleAnim")&&animator.GetCurrentAnimatorClipInfo(0).Length<animator.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            animator.SetBool("collidedWithCoin", false);

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
    private void ShowParametersNamesAtInspector()
    {
        for (int i = 0; i < animatorParametersCount; i++)
        {
            animationParametersNames.Add(animator.GetParameter(i).name);
        }
    }
}
