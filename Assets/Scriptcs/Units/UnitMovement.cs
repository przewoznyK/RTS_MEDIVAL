using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class UnitMovement : MonoBehaviour
{
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected Animator animator;
   // [SerializeField] private UnitGatheringResources unitGatheringResources;
    //[SerializeField] private float startGatheringDistance;
    [SerializeField] protected LayerMask ground;
    protected Vector3 targetLocation;

    //[Header("GatheringResources")]
    //[SerializeField] private bool canGatheringResources;
    //[SerializeField] private bool canGatheringWood;
    //[SerializeField] private bool canGatheringStone;
    //[SerializeField] private LayerMask stoneResourceMask;
    //[SerializeField] private LayerMask woodResourceMask;
    //private Vector3 resourcePosition;
    //public bool isMovingToResources;
    //private ResourceTypesEnum newCurrentGatheringResource;
    //[Header("IsBuilder")]
    //[SerializeField] private bool isBuilder;
    //[SerializeField] private LayerMask toBulitMask;
    //[SerializeField] private LayerMask attackableMask;
    //void Start()
    //{
    //    resourcePosition = Vector3.zero;

    //}
    //private void OnEnable()
    //{
    //    if (isBuilder)
    //        ShopUI.instance.SetActivePanel(true);
    //    else
    //        ShopUI.instance.SetActivePanel(false);
    //}
    void Update()
    {
        //Debug.Log(2);
        //if (Input.GetMouseButtonDown(1) && PreviewSystem.instance.isOnPreview == false)
        //{
        //    Debug.Log(1);
        //    SetUnitDestination();
        //}
        //if(isMovingToResources)
        //{
        //    UnitGoingToGatcheringResource();
        //}
    }
    internal void GoMeetingPosition(Vector3 meetingPosition)
    {
        agent.SetDestination(meetingPosition);
        this.enabled = false;
    }

    public virtual void SetUnitDestination()
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

    //void UnitGoingToGatcheringResource()
    //{
    //    if (Vector3.Distance(transform.position, resourcePosition) <= startGatheringDistance + 0.5f)
    //    {
    //        //    unitStats.SetCurrentGatheringResource(newCurrentGatheringResource);

    //        unitGatheringResources.enabled = true;
    //    //    unitGatheringResources.SetCurrentGatheringTypeEnum(ResourceTypesEnum.wood);
    //        unitGatheringResources.StartGathering();
    //     //   animator.SetBool("IsWalking", false);
    //        transform.GetChild(0).gameObject.SetActive(false);
    //        resourcePosition = Vector3.zero;
    //        isMovingToResources = false;
    //        Debug.Log("ZACZYNAMY BUDOWAC");
    //        this.enabled = false;

    //    }
    //}



    //internal void GoBuildingObject(GameObject newObject)
    //{
    //    Debug.Log("START BUILDING");
    //    resourcePosition = newObject.transform.position;
    //    agent.SetDestination(newObject.transform.position);
    //  //  newCurrentGatheringResource = ResourceTypesEnum.building;
    //    isMovingToResources = true;
    //    agent.stoppingDistance = startGatheringDistance;
    //    var component = newObject.gameObject.GetComponent<BuildingToBulit>();
    //    if (component != null)
    //    {
    //        unitGatheringResources.SetBuildingToBuild(component);
    //    }
    //}
}
