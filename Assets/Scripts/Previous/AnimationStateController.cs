using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    // animator string to hash function
    int IsWalkingHash;
    int IsJumpingHash;
    int IsEatingHash;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        IsWalkingHash = Animator.StringToHash("IsWalking");
        IsJumpingHash = Animator.StringToHash("IsJumping");
        IsEatingHash = Animator.StringToHash("IsEating");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        //bool IsWalking=animator.GetBool(IsWalkingHash);
        //bool IsJumping=animator.GetBool(IsJumpingHash);
        //bool IsEating=animator.GetBool(IsEatingHash);
        ////bool forwardPressed = Input.GetKey("w");
        //float VerticalPressed = Input.GetAxis("Vertical");
        //float HorizontalPressed = Input.GetAxis("Horizontal");

        //// if player presses w key
        //if(!IsWalking&&(VerticalPressed!=0||HorizontalPressed!=0))
        //{
        //    // then set the isWalking boolean to be tr
        //    animator.SetBool(IsWalkingHash, true);
        //}

        //// if player is not pressing
        //if(IsWalking&&(VerticalPressed==0&&HorizontalPressed==0))
        //{
        //    animator.SetBool(IsWalkingHash, false);
        //}

        //if(!IsJumping&&(Input.GetKeyDown("j")))
        //{

        //    animator.SetBool(IsJumpingHash, true);
          
        //}
        //if(IsJumping&&(Input.GetKeyDown("j")))
        //{

        //    animator.SetBool(IsJumpingHash, false);
           
        //}

        //if(!IsEating&&(Input.GetKeyDown("n")))
        //{

        //    animator.SetBool(IsEatingHash, true);
          
        //}
        //if(IsJumping&&(Input.GetKeyDown("n")))
        //{

        //    animator.SetBool(IsEatingHash, false);
           
        //}
     
    }
}
