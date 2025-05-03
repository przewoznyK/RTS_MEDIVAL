using System.Collections.Generic;
using System.Resources;
using UnityEngine;

public class UnitMovementGatherer : UnitMovement
{
    [Header("Unit Movement Gatherer")]
    [SerializeField] private UnitGatherer unitGatherer;
    [SerializeField] private UnitGatheringResources unitGatheringResources;
    [SerializeField] private UnitGathererType unitGathererType;
    [SerializeField] private ResourceTypesEnum newCurrentGatheringResource;
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
        unitGatheringResources.RemoveFromResourceList();

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (canGatheringWood && Physics.Raycast(ray, out hit, Mathf.Infinity, woodResourceMask))
        {
            Resource resource = hit.collider.gameObject.GetComponent<Resource>();
            unitGatheringResources.enabled = true;
            unitGatheringResources.GoToResource(resource, hit.point, ResourceTypesEnum.wood);

        }
        else if (canGatheringStone && Physics.Raycast(ray, out hit, Mathf.Infinity, stoneResourceMask))
        {
            Resource resource = hit.collider.gameObject.GetComponent<Resource>();

            unitGatheringResources.enabled = true;
            unitGatheringResources.GoToResource(resource, hit.point, ResourceTypesEnum.stone);
            this.enabled = false;
            unitGatherer.DeactiveUnit();



        }
        else if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        {
            agent.SetDestination(hit.point);
            unitGatheringResources.enabled = false;
         }
        
    }





}