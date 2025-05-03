using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class Unit : MonoBehaviour, IActiveClickable
{
    [SerializeField] protected UnitMovement unitMovement;
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected Animator animator;
    [SerializeField] protected CapsuleCollider capsuleCollider;
    [SerializeField] protected GameObject activator;
    [SerializeField] protected UnitStats unitStats;
    protected UnitRuntimeData unitData;
    [SerializeField] protected string unitName;
    [SerializeField] protected UnitTypeEnum unitType;
    [SerializeField] protected TeamColorEnum teamColorEnum;
    void Start()
    {
        unitData = new UnitRuntimeData(unitStats.Name, unitStats.unitType, unitStats.Sprite, unitStats.maxHealth); 
        UnitSelections.Instance.unitList.Add(this.gameObject);
    }
    public virtual void ActiveObject()
    {
        unitMovement.enabled = true;
        unitMovement.IsActiveFromPlayerMouse();
        UnitUI.instance.ActiveUnitPanelAndPrepareButtons(unitData);
    }


    private void OnDestroy()
    {
        UnitSelections.Instance.unitList.Remove(this.gameObject);
    }
    private void Update()
    {
        animator.SetBool("IsWalking", agent.velocity.magnitude > 0.01f);
    }

    internal void SetUnitName(string name)
    {
        unitName = name;
    }
    public void SetUnitStats(UnitStats unitStatsToSet)
    {
        unitStats = unitStatsToSet;
    }
    public UnitTypeEnum GetUnitType()
    {
        return unitType;
    }
    public void SetUnitType(UnitTypeEnum newUnitType)
    {
        unitType = newUnitType;
    }

    internal TeamColorEnum GetTeamColor()
    {
        return teamColorEnum;

    }

    public void Death()
    {
        gameObject.tag = "DeathBody";
        gameObject.layer = 0;
        agent.isStopped = true;
        capsuleCollider.enabled = false;
        unitMovement.enabled = false;
        activator.SetActive(false);

    }

    public void DeactiveUnit()
    {
        activator.SetActive(false);
    }

    public UnitRuntimeData GetUnitStats()
    {
        return unitData;
    }
}
