using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class UnitMovement : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected Animator animator;
    [SerializeField] protected UnitAttack unitAttack;
    [SerializeField] protected LayerMask ground;
    [SerializeField] protected LayerMask attackable;
    protected Vector3 targetLocation;
    [SerializeField] protected Transform targetAttackTransform;
    [SerializeField] protected float startAttackingDistance;
    // protected bool isMovingToAttackTarget;
    bool attackCourtineStart = false;
    protected bool isActiveFromPlayerMouse;
    internal void GoMeetingPosition(Vector3 meetingPosition)
    {
        agent.SetDestination(meetingPosition);
        this.enabled = false;
    }

    public virtual void SetUnitDestination()
    {
        targetAttackTransform = null;
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, attackable))
        {
            GoToTheAttackTarget(hit.transform);
        }
        else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        {
            agent.SetDestination(hit.point);
        }
    }

    protected void UnitGoingToAttackTarget()
    {
        if (Vector3.Distance(transform.position, targetAttackTransform.position) <= startAttackingDistance)
        {
            if(agent.velocity.magnitude <= 0.5f && attackCourtineStart == false)
            {
                unitAttack.enabled = true;
                unitAttack.StartAttacking();
                attackCourtineStart = true;
            }
        
        }
        else
        {
            attackCourtineStart = false;
            unitAttack.enabled = false;
            agent.SetDestination(targetAttackTransform.position);
        }
    }

    public void IsActiveFromPlayerMouse()
    {
        isActiveFromPlayerMouse = true;
    }

    internal void GoToTheAttackTarget(Transform transform)
    {
        targetAttackTransform = transform; 

    }


}
