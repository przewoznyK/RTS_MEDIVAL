using System.Collections.Generic;
using UnityEngine;

public class UnitMovementGatherer : UnitMovement
{
    [Header("Unit Movement Gatherer")]
    [SerializeField] private UnitGatherer unitGatherer;
    [SerializeField] private UnitGatheringResources unitGatheringResources;
    [SerializeField] private UnitGathererType unitGathererType;
    [SerializeField] private ResourceTypesEnum newCurrentGatheringResource;

    private bool isMovingToResources;
    private Vector3 resourcePosition;
    [Header("Resources")]
    [SerializeField] private bool canGatheringWood;
    [SerializeField] private bool canGatheringStone;
    [Header("LayerMask")]
    [SerializeField] private LayerMask woodResourceMask;
    [SerializeField] private LayerMask stoneResourceMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && PreviewSystem.instance.isOnPreview == false)
        {
            SetUnitDestination();
        }

    }

    public override void SetUnitDestination()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        isMovingToResources = false;

        if (canGatheringWood && Physics.Raycast(ray, out hit, Mathf.Infinity, woodResourceMask))
        {
            unitGatheringResources.enabled = true;
            unitGatheringResources.GoToResource(hit.point, ResourceTypesEnum.wood);

        }
        else if (canGatheringStone && Physics.Raycast(ray, out hit, Mathf.Infinity, stoneResourceMask))
        {
            unitGatheringResources.enabled = true;
            unitGatheringResources.GoToResource(hit.point, ResourceTypesEnum.stone);
        
     
  
        }

        if(!isMovingToResources)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                agent.SetDestination(hit.point);
             //   unitGatheringResources.enabled = false;
            }
        }
    }





}