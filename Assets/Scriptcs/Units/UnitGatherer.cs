using System.Collections.Generic;
using UnityEngine;

public enum UnitGathererType
{
    lumberjack,
    miner
}

public class UnitGatherer : Unit
{
    [SerializeField] private Dictionary<ResourceTypesEnum, int> currentUnitResourcesDictionary = new();
    [SerializeField] private int maxResources = 6;
    public void AddResourceToDictionary(ResourceTypesEnum resourceType, int value)
    {
        if(currentUnitResourcesDictionary.ContainsKey(resourceType))
        {
            currentUnitResourcesDictionary[resourceType] += value;
            if (currentUnitResourcesDictionary[resourceType] > maxResources)
            {
                
                Storage storage = ResourcesManager.instance.GetNearestStorage(resourceType, transform);
                unitMovement.GoToBuilding(storage);
            }
            Debug.Log(currentUnitResourcesDictionary[resourceType]);
        }
        else
            currentUnitResourcesDictionary.Add(resourceType, value);
    }

    
}
