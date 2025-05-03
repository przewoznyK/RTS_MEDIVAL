using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.AI;

public class UnitGatheringResources : MonoBehaviour
{
    [SerializeField] private UnitGatherer unitGatherer;
    [SerializeField] private UnitMovementGatherer unitMovementGatherer;
    [SerializeField] private Animator animator;
    [SerializeField] private NavMeshAgent agent;

    [Header("Resources")]
    [SerializeField] private float startGatheringDistance;
    Vector3 resourcePosition;
    private bool isMovingToResources;
    private ResourceTypesEnum currentGatherignResourceEnum;
    [SerializeField] private Dictionary<ResourceTypesEnum, int> currentUnitResourcesDictionary = new();
    private Coroutine gatheringRoutine;
    [SerializeField]private Resource resource;
    [Header("Storage")]
    [SerializeField] private int maxResourcesAmount = 6;
    private Storage currentTargetStorage;
    private bool isMovingToStorage;
    private void OnDisable()
    {
        StopMining();
    }

    private void Update()
    {
        if(isMovingToResources)
        {
            UnitGoingToGatcheringResource();
        }

        if (isMovingToStorage)
        {

            if (Vector3.Distance(transform.position, currentTargetStorage.transform.position) <= 3f)
            {
                currentUnitResourcesDictionary = currentTargetStorage.PutInResourcesInStorage(currentUnitResourcesDictionary);
                isMovingToStorage = false;
                ReturnToResource();
            }
        }
    }

    public void AddResourceToDictionary(ResourceTypesEnum resourceType, int value)
    {
        if (currentUnitResourcesDictionary.ContainsKey(resourceType))
        {
            currentUnitResourcesDictionary[resourceType] += value;
            if (currentUnitResourcesDictionary[resourceType] > maxResourcesAmount)
            {
                Storage storage = ResourcesManager.instance.GetNearestStorage(resourceType, transform);
                GoToStorage(storage);
            }
        }
        else
            currentUnitResourcesDictionary.Add(resourceType, value);
    }

    public void SubstractResourceInDictionary(ResourceTypesEnum resourceType, int value)
    {
        if (currentUnitResourcesDictionary.ContainsKey(resourceType))
        {
            currentUnitResourcesDictionary[resourceType] -= value;
        }
    }

    public void StartGathering()
    {
        switch (currentGatherignResourceEnum)
        {
            case ResourceTypesEnum.wood:
                gatheringRoutine = StartCoroutine(GatheringWoodCycle());
                break;
            case ResourceTypesEnum.stone:
                gatheringRoutine = StartCoroutine(GatheringStoneCycle());
                break;
        }
    }


    IEnumerator GatheringWoodCycle()
    {
        animator.SetBool("IsMining", true);
        while (resource != null)
        {
            yield return new WaitForSeconds(3f);
            if (resource == null)
                break;
            AddResourceToDictionary(ResourceTypesEnum.wood, 3);
            resource.SubstractResource(3);
        }
    }
    IEnumerator GatheringStoneCycle()
    {
        animator.SetBool("IsMining", true);
        while (resource != null)
        {
            yield return new WaitForSeconds(3f);
            if (resource == null)
                break;
            AddResourceToDictionary(ResourceTypesEnum.stone, 3);
            resource.SubstractResource(3);
        }
    }


    public void SetCurrentGatheringTypeEnum(ResourceTypesEnum gatheringResourceTypeEnum)
    {
        currentGatherignResourceEnum = gatheringResourceTypeEnum;
    }

    public void GoToStorage(Storage storage)
    {
        currentTargetStorage = storage;
        agent.SetDestination(currentTargetStorage.transform.position);
        animator.SetBool("IsMining", false);
        StopCoroutine(gatheringRoutine);
        isMovingToStorage = true;
     
    }

    internal void GoToResource(Resource resourceToSet, Vector3 resourcePositionToSet, ResourceTypesEnum currentGatherignResourceEnumToSet)
    {
        resource = resourceToSet;
        resourceToSet.AddUnitGatheringToList(this);
        resourcePosition = resourcePositionToSet;
        agent.SetDestination(resourcePosition);
        currentGatherignResourceEnum = currentGatherignResourceEnumToSet;
        isMovingToResources = true;
        agent.stoppingDistance = startGatheringDistance;

    }
    void ReturnToResource()
    {
        agent.SetDestination(resourcePosition);
        isMovingToResources = true;
        agent.stoppingDistance = startGatheringDistance;

    }
    void UnitGoingToGatcheringResource()
    {
        if (Vector3.Distance(transform.position, resourcePosition) <= startGatheringDistance + 0.5f)
        {          
            if(resource != null)
            {
                StartGathering();
                isMovingToResources = false;

            }
        }
    }

    public void StopMining()
    {
        animator.SetBool("IsMining", false);
        resource = null;
    }
    
    public void RemoveFromResourceList()
    {
        if (resource != null)
            resource.DeleteUnitGatheringFromList(this);
    }
}
