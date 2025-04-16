using UnityEngine;

public class UnitMovementGatherer : UnitMovement
{
    [SerializeField] private UnitGathererType unitGathererType;
    public override void SetUnitDestination()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        {
            Debug.Log(2);
            //    resourcePosition = hit.point;
            agent.SetDestination(hit.point);
            Debug.Log("IDE");
            //    unitGatheringResources.enabled = false;
            //agent.stoppingDistance = startGatheringDistance;
        }
        //isMovingToResources = false;
        //if (canGatheringResources)
        //{
        //    if (canGatheringWood && Physics.Raycast(ray, out hit, Mathf.Infinity, woodResourceMask))
        //    {

        //        resourcePosition = hit.point;
        //        agent.SetDestination(hit.point);
        //        newCurrentGatheringResource = ResourceTypesEnum.wood;
        //        isMovingToResources = true;
        //        agent.stoppingDistance = startGatheringDistance;

        //    }
        //    else if (canGatheringStone && Physics.Raycast(ray, out hit, Mathf.Infinity, stoneResourceMask))
        //    {
        //        resourcePosition = hit.point;
        //        agent.SetDestination(hit.point);
        //        newCurrentGatheringResource = ResourceTypesEnum.stone;
        //        isMovingToResources = true;
        //        agent.stoppingDistance = startGatheringDistance;


        //    }
        //    else if (canGatheringStone && Physics.Raycast(ray, out hit, Mathf.Infinity, attackableMask))
        //    {
        //        resourcePosition = hit.point;
        //        agent.SetDestination(hit.point);
        //        newCurrentGatheringResource = ResourceTypesEnum.stone;
        //        isMovingToResources = true;
        //        agent.stoppingDistance = startGatheringDistance;


        //    }
        //}
        //else if(isBuilder)
        //{
        //    if (Physics.Raycast(ray, out hit, Mathf.Infinity, toBulitMask))
        //    {
        //        Debug.Log(1);
        //        resourcePosition = hit.point;
        //        agent.SetDestination(hit.point);
        //        newCurrentGatheringResource = ResourceTypesEnum.building;
        //        isMovingToResources = true;
        //        agent.stoppingDistance = startGatheringDistance;
        //        var component = hit.collider.gameObject.GetComponent<BuildingToBulit>();
        //        if (component != null)
        //        {
        //            unitGatheringResources.SetBuildingToBuild(component);
        //        }

        //    }
        ////}

        //if(!isMovingToResources)
        //{
        //    if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        //    {

        //    //    resourcePosition = hit.point;
        //        agent.SetDestination(hit.point);
        //        unitGatheringResources.enabled = false;
        //        //agent.stoppingDistance = startGatheringDistance;
        //    }
        //}


    }
}
