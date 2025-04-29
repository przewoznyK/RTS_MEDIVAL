using UnityEngine;

public class UnitMovementGatherer : UnitMovement
{
    [SerializeField] private UnitGatheringResources unitGatheringResources;
    [SerializeField] private UnitGathererType unitGathererType;
    [SerializeField] private ResourceTypesEnum newCurrentGatheringResource;
    [SerializeField] private float startGatheringDistance;
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
        if (isMovingToResources)
        {
            UnitGoingToGatcheringResource();
        }
    }

    public override void SetUnitDestination()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        isMovingToResources = false;

        if (canGatheringWood && Physics.Raycast(ray, out hit, Mathf.Infinity, woodResourceMask))
        {
            resourcePosition = hit.point;
            agent.SetDestination(hit.point);
            newCurrentGatheringResource = ResourceTypesEnum.wood;
            isMovingToResources = true;
            agent.stoppingDistance = startGatheringDistance;

        }
        else if (canGatheringStone && Physics.Raycast(ray, out hit, Mathf.Infinity, stoneResourceMask))
        {
            resourcePosition = hit.point;
            agent.SetDestination(hit.point);
            newCurrentGatheringResource = ResourceTypesEnum.stone;
            isMovingToResources = true;
            agent.stoppingDistance = startGatheringDistance;
        }

        if(!isMovingToResources)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                agent.SetDestination(hit.point);
                unitGatheringResources.enabled = false;
                agent.stoppingDistance = startGatheringDistance;
            }
        }
    }

    void UnitGoingToGatcheringResource()
    {
        if (Vector3.Distance(transform.position, resourcePosition) <= startGatheringDistance + 0.5f)
        {
            unitGatheringResources.enabled = true;
            unitGatheringResources.SetCurrentGatheringTypeEnum(newCurrentGatheringResource);
            unitGatheringResources.StartGathering();
            transform.GetChild(0).gameObject.SetActive(false);
            resourcePosition = Vector3.zero;
            isMovingToResources = false;
            this.enabled = false;
        }
    }

}