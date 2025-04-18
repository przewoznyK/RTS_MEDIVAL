using UnityEngine;
using UnityEngine.AI;

public class UnitMovementBuilder : UnitMovement
{
    [SerializeField] private UnitBuilderBuildObject unitBuilderBuildObject;
        private BuildingToBulit buildingToBulit;
    [SerializeField] private float startBuildDistance;
    private bool isMovingToBuild;
    private Vector3 toBulidPosition;
    [Header("Layers")]
    [SerializeField] private LayerMask toBuildMask;

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && PreviewSystem.instance.isOnPreview == false)
        {
            SetUnitDestination();
        }
        if (isMovingToBuild)
        {
            UnitGoingToBuilldObject();
        }
    }

    public override void SetUnitDestination()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        isMovingToBuild = false;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, toBuildMask))
        {
            toBulidPosition = hit.point;
            agent.SetDestination(hit.point);
            isMovingToBuild = true;
            agent.stoppingDistance = startBuildDistance;
            buildingToBulit = hit.collider.GetComponent<BuildingToBulit>();
        }

        if (!isMovingToBuild)
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                agent.SetDestination(hit.point);
                //   unitGatheringResources.enabled = false;
                unitBuilderBuildObject.enabled = false;
                agent.stoppingDistance = startBuildDistance;
            }
        }
    }

    void UnitGoingToBuilldObject()
    {
        if (Vector3.Distance(transform.position, toBulidPosition) <= startBuildDistance)
        {
            Debug.Log("START");
            unitBuilderBuildObject.enabled = true;
            unitBuilderBuildObject.SetBuildingToBuild(buildingToBulit);
            unitBuilderBuildObject.StartBuild();

            transform.GetChild(0).gameObject.SetActive(false);
            toBulidPosition = Vector3.zero;
            isMovingToBuild = false;
            this.enabled = false;
        }
    }

    internal void GoBuildingObject(GameObject newObject)
    {
        unitBuilderBuildObject.enabled = false;
        toBulidPosition = newObject.transform.position;
        agent.SetDestination(newObject.transform.position);
    
        agent.stoppingDistance = startBuildDistance;
        var component = newObject.gameObject.GetComponent<BuildingToBulit>();
        if (component != null)
        {
            buildingToBulit = component;
        }

        isMovingToBuild = true;
    }
}
