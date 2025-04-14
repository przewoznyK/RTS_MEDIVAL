using System;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private UnitGatheringResources unitGatheringResources;
    [SerializeField] private float startGatheringDistance;
    [SerializeField] private LayerMask ground;
    [SerializeField] private Vector3 targetLocation;
    [Header("GatheringResources")]
    [SerializeField] private bool canGatheringResources;
    [SerializeField] private bool canGatheringWood;
    [SerializeField] private bool canGatheringStone;
    [SerializeField] private LayerMask stoneResourceMask;
    [SerializeField] private LayerMask woodResourceMask;
    private Vector3 resourcePosition;
    public bool isMovingToResources;
    private ResourceTypesEnum newCurrentGatheringResource;
    [Header("IsBuilder")]
    [SerializeField] private bool isBuilder;
    [SerializeField] private LayerMask toBulitMask;
    void Start()
    {
        resourcePosition = Vector3.zero;

    }
    private void OnEnable()
    {
        if (isBuilder)
            ShopUI.instance.SetActivePanel(true);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            SetUnitDestination();
        }
        if(isMovingToResources)
        {
            UnitGoingToGatcheringResource();
        }
    }

    void SetUnitDestination()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        isMovingToResources = false;
        if (canGatheringResources)
        {
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
        }
        else if(isBuilder)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, toBulitMask))
            {
                Debug.Log(1);
                resourcePosition = hit.point;
                agent.SetDestination(hit.point);
                newCurrentGatheringResource = ResourceTypesEnum.building;
                isMovingToResources = true;
                agent.stoppingDistance = startGatheringDistance;
                var component = hit.collider.gameObject.GetComponent<BuildingToBulit>();
                if (component != null)
                {
                    unitGatheringResources.SetBuildingToBuild(component);
                }

            }
        }
        if(!isMovingToResources)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {

            //    resourcePosition = hit.point;
                agent.SetDestination(hit.point);
                unitGatheringResources.enabled = false;
                //agent.stoppingDistance = startGatheringDistance;
            }
        }


    }

    void UnitGoingToGatcheringResource()
    {
        if (Vector3.Distance(transform.position, resourcePosition) <= startGatheringDistance + 0.5f)
        {
            //    unitStats.SetCurrentGatheringResource(newCurrentGatheringResource);
            
            unitGatheringResources.enabled = true;
        //    unitGatheringResources.SetCurrentGatheringTypeEnum(ResourceTypesEnum.wood);
            unitGatheringResources.StartGathering();
         //   animator.SetBool("IsWalking", false);
            transform.GetChild(0).gameObject.SetActive(false);
            resourcePosition = Vector3.zero;
            isMovingToResources = false;
            this.enabled = false;

        }
    }

    internal void GoMeetingPosition(Vector3 meetingPosition)
    {
        agent.SetDestination(meetingPosition);
        this.enabled = false;
    }
}
