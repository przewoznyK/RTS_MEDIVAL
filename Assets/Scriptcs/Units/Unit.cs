using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class Unit : MonoBehaviour, IActiveClickable
{
    [SerializeField] protected UnitMovement unitMovement;
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected Animator animator;
    [SerializeField] protected string unitName;
    [SerializeField] protected UnitTypeEnum unitType;

    //[SerializeField] private GameObject activator;
    //private bool isActive;
    void Start()
    {
        UnitSelections.Instance.unitList.Add(this.gameObject);
        //      isActive = false;
    }
    public virtual void ActiveObject()
    {
        unitMovement.enabled = true;
        unitMovement.IsActiveFromPlayerMouse();
        UnitUI.instance.ActiveUnitPanelAndPrepareButtons(unitName);
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
    public UnitTypeEnum GetUnitType()
    {
        return unitType;
    }
    public void SetUnitType(UnitTypeEnum newUnitType)
    {
        unitType = newUnitType;
    }
    //void Update()
    //{


    //    if (Input.GetMouseButtonDown(1) && isActive)
    //    {
    //        RaycastHit hit;

    //        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
    //        {
    //            agent.destination = hit.point;
    //        }
    //    }

    //    animator.SetBool("IsWalking", agent.velocity.magnitude > 0.01f);
    //}

    //public void ActiveUnit()
    //{

    //    activator.SetActive(true);
    //    isActive = true;
    //}
    //public void DeactiveUnit()
    //{
    //    activator.SetActive(false);
    //    isActive = false;
    //}

}
