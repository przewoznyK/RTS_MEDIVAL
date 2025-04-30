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
    bool attackCourtineStart = false;
    protected bool isActiveFromPlayerMouse;
    [Header("DEBUG")]
    [SerializeField] protected Transform targetAttackTransform;
    internal void GoMeetingPosition(Transform meetingPosition)
    {
        agent.SetDestination(meetingPosition.position);
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
            // CHECKING IF UNIT IS NEAR TO TARGET
            if(agent.velocity.magnitude <= 0.5f && attackCourtineStart == false)
            {
                //START ATTACKING
                unitAttack.enabled = true;
                unitAttack.StartAttacking();
                attackCourtineStart = true;
            }
        
        }
        else
        {
            // STOP ATTACKING
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

    public void FaceTarget()
    {
        Vector3 direction = (targetAttackTransform.position - transform.position).normalized;
        direction.y = 0f;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    public virtual void GoToStorage(Storage storage)
    {
        agent.SetDestination(storage.gameObject.transform.position);
    }
}
