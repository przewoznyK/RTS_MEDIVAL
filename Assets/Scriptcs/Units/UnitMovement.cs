using UnityEngine;
using UnityEngine.AI;

public class UnitMovement : MonoBehaviour
{
    Camera myCam;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    [SerializeField] private UnitGatheringResources unitGatheringResources;
    [SerializeField] private float startGatheringDistance;
    [SerializeField] private LayerMask ground;
    [Header("GatheringResources")]
    [SerializeField] private bool canGatheringResources;
    [SerializeField] private bool canGatheringWood;
    [SerializeField] private bool canGatheringStone;
    [SerializeField] private LayerMask stoneResourceMask;
    [SerializeField] private LayerMask woodResourceMask;
    private Vector3 resourcePosition;
    public bool isMovingToResources;
    private ResourceTypesEnum newCurrentGatheringResource;
    void Start()
    {
        myCam = Camera.main;
        resourcePosition = Vector3.zero;
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
        animator.SetBool("IsWalking", agent.velocity.magnitude > 0.01f);
    }

    void SetUnitDestination()
    {
        RaycastHit hit;
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
        if(canGatheringResources)
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
        if(!isMovingToResources)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                if (canGatheringResources)
                    unitGatheringResources.enabled = false;
                agent.SetDestination(hit.point);

            }
        }


    }

    void UnitGoingToGatcheringResource()
    {
        if (Vector3.Distance(transform.position, resourcePosition) <= startGatheringDistance + 0.5f)
        {
            //    unitStats.SetCurrentGatheringResource(newCurrentGatheringResource);
            
            unitGatheringResources.enabled = true;
            unitGatheringResources.SetCurrentGatheringTypeEnum(GatheringResourceTypeEnum.wood);
            unitGatheringResources.StartGathering();
            animator.SetBool("IsWalking", false);
            transform.GetChild(0).gameObject.SetActive(false);
            resourcePosition = Vector3.zero;
            isMovingToResources = false;
            this.enabled = false;

        }
    }
}
