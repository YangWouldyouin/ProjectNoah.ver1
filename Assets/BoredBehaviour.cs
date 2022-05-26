using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoredBehaviour : StateMachineBehaviour
{
    // 현재 플레이어 위치 중심으로 일정 범위
    NavMeshAgent navMeshAgent;
    Transform playerTransform;

    public LayerMask whatIsGround;
    [SerializeField] float _timeUntilBored;
    [SerializeField] int _numberOfBoredAnimations;
    bool _isBored;
    float _idleTime;

    bool IsWalkPointSet;
    float walkPointRange;
    Vector3 walkPoint;

    [SerializeField] int _boredAnimation;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navMeshAgent = BaseCanvas._baseCanvas.agent;
        playerTransform = BaseCanvas._baseCanvas.noahPlayer.transform;
        ResetIdle();
    }

    void Patrolling(Animator animator)
    {
        if(!IsWalkPointSet)
        {
            SearchWalkPoint();
        }
        if(IsWalkPointSet)
        {
            navMeshAgent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = playerTransform.position - walkPoint;

        if(distanceToWalkPoint.magnitude<1f)
        {
            IsWalkPointSet = false;
            _isBored = true;
            _boredAnimation = Random.Range(1, _numberOfBoredAnimations + 1);
            _boredAnimation = _boredAnimation * 2 - 1;
            animator.SetFloat("BoredAnimation", _boredAnimation - 1);
        }
    }

    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange );
        float randomX= Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(playerTransform.position.x + randomX, playerTransform.position.y, playerTransform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -playerTransform.up, 2f, whatIsGround))
        {
            IsWalkPointSet = true;
        }
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!_isBored)
        {
            _idleTime += Time.deltaTime;

            if(_idleTime> _timeUntilBored && stateInfo.normalizedTime%1<0.02f)
            {
                Patrolling(animator);

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
