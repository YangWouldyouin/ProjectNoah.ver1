using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoredBehaviour : StateMachineBehaviour
{
 
    [SerializeField] float _timeUntilBored;
    [SerializeField] int _numberOfBoredAnimations;
    bool _isBored;
    float _idleTime;

    [SerializeField] int _boredAnimation;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetIdle();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!_isBored)
        {
            _idleTime += Time.deltaTime;

            if(_idleTime> _timeUntilBored && stateInfo.normalizedTime%1<0.02f)
            {
                _isBored = true;
                _boredAnimation = Random.Range(1, _numberOfBoredAnimations + 1);
                _boredAnimation = _boredAnimation * 2 - 1;
                animator.SetFloat("BoredAnimation", _boredAnimation - 1);
            }
        }
        else if(stateInfo.normalizedTime%1>0.98f)
        {
            ResetIdle();
        }
        animator.SetFloat("BoredAnimation", _boredAnimation, 0.1f, Time.deltaTime);
    }

    private void ResetIdle()
    {
        if(_isBored)
        {
            _boredAnimation -= 1;
        }
        _isBored = false;
        _idleTime = 0;
        //_boredAnimation = 0;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
