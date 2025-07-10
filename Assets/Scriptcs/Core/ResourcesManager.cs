using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager instance;
    [SerializeField] private List<Storage> blueWoodStorage = new();
    [SerializeField] private List<Storage> blueStoneStorage = new();
    private void Awake()
    {
        instance = this;
    }
    public void AddNewStorage(Storage storage, ResourceTypesEnum resoruceType, TeamColorEnum team)
    {
        switch (resoruceType)
        {
            case ResourceTypesEnum.wood:
                blueWoodStorage.Add(storage);
                break;
            case ResourceTypesEnum.stone:
                blueStoneStorage.Add(storage);
            break;
     
        }

    }

    public Storage GetNearestStorage(ResourceTypesEnum storageType, Transform currentUnitPosition)
    {
        Storage nearestStorage = null;
        List<Storage> currentStorage = new();
        float minDistance = Mathf.Infinity;

        switch (storageType)
        {
            case ResourceTypesEnum.wood:
                currentStorage = blueWoodStorage;
                break;
            case ResourceTypesEnum.stone:
                currentStorage = blueStoneStorage;

                break;
            default:
                break;
        }

        foreach (var storage in blueStoneStorage)
        {
            float dist = Vector3.Distance(currentUnitPosition.position, storage.transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                nearestStorage = storage;
            }
        }

        return nearestStorage;
    }
}
