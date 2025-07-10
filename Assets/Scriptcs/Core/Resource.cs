using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    [SerializeField] private int resourceAmount = 100;
    List<UnitGatheringResources> unitGatheringResourcesList = new();
    public void SubstractResource(int value)
    {
        resourceAmount -= value;
        if (resourceAmount <= 0)
        {
            foreach (var unitGathering in unitGatheringResourcesList)
            {
                unitGathering.StopMining();

            }
            unitGatheringResourcesList.Clear();
            Destroy(gameObject);
        }
    }

    public void AddUnitGatheringToList(UnitGatheringResources unitGatheringResources)
    {
        unitGatheringResourcesList.Add(unitGatheringResources);
    }
    public void DeleteUnitGatheringFromList(UnitGatheringResources unitGatheringResources)
    {
        if (unitGatheringResourcesList.Contains(unitGatheringResources))
        {
            unitGatheringResourcesList.Remove(unitGatheringResources);
        }
    }
}
