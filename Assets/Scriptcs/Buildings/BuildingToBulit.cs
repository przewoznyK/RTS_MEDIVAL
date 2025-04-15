using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingToBulit : MonoBehaviour
{
    [SerializeField] private GameObject finishBuilding;
    [SerializeField] private int timeToBuilt;
    List<UnitGatheringResources> unitGatheringResourcesList = new();
    public void SetFinishBuilding(GameObject builtToCreate)
    {
        finishBuilding = builtToCreate;
    }

    internal void EndProcess()
    {
        Instantiate(finishBuilding, transform.position, Quaternion.identity);
        foreach (var unitGathering in unitGatheringResourcesList)
        {

            unitGathering.enabled = false;
        }
        Destroy(gameObject);
    }

    public void WorkOnBuilding(int value)
    {
        if(timeToBuilt > 0)
        {
            timeToBuilt -= value;
        }
        else
        {
            EndProcess();
        }
    }

    public void AddToActiveBuildersList(UnitGatheringResources unitGatheringResources)
    {
        unitGatheringResourcesList.Add(unitGatheringResources);
    }
}
