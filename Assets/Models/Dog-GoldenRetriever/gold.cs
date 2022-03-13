using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold : MonoBehaviour
{
    Animator aanimator;
    // animator string to hash function
    int IsWalkingHashh;



    // Start is called before the first frame update
    void Start()
    {
        aanimator = GetComponent<Animator>();
        IsWalkingHashh = Animator.StringToHash("IsWalking");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        bool IsWalking=aanimator.GetBool(IsWalkingHashh);

        //bool forwardPressed = Input.GetKey("w");
        float VerticalPressedd = Input.GetAxis("Vertical");
        float HorizontalPressedd = Input.GetAxis("Horizontal");

        // if player presses w key
        if(!IsWalking&&(VerticalPressedd!=0||HorizontalPressedd!=0))
        {
            // then set the isWalking boolean to be tr
            aanimator.SetBool(IsWalkingHashh, true);
        }

        // if player is not pressing
        if(IsWalking&&(VerticalPressedd==0&&HorizontalPressedd==0))
        {
            aanimator.SetBool(IsWalkingHashh, false);
        }

      
     
    }
}

