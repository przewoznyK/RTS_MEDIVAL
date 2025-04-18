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
    [SerializeField] protected float startAttackingDistance;
    protected bool isMovingToAttackTarget;
    internal void GoMeetingPosition(Vector3 meetingPosition)
    {
        agent.SetDestination(meetingPosition);
        this.enabled = false;
    }

    public virtual void SetUnitDestination()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, Mathf.Infinity, attackable))
        {
            agent.SetDestination(hit.point);
            isMovingToAttackTarget = true;
            targetLocation = hit.point;

        }
        else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        {
            agent.SetDestination(hit.point);
        }
    }

    protected void UnitGoingToAttackTarget()
    {
        if (Vector3.Distance(transform.position, targetLocation) <= startAttackingDistance + 0.5f)
        {
            unitAttack.enabled = true;
            //   unitGatheringResources.SetCurrentGatheringTypeEnum(newCurrentGatheringResource);
            unitAttack.StartAttacking();
            //    transform.GetChild(0).gameObject.SetActive(false);
            targetLocation = Vector3.zero;
            isMovingToAttackTarget = false;
            this.enabled = false;
        }
    }
}
