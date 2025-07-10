using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Storage : MonoBehaviour
{
    [SerializeField] private Building building;
    [SerializeField] private ResourceTypesEnum[] resourcesToStargeList;

    private void Start()
    {
        foreach (var storageType in resourcesToStargeList)
        {
            if(storageType != ResourceTypesEnum.none)
                ResourcesManager.instance.AddNewStorage(this, storageType, building.teamColor);

        }
    }

    public Dictionary<ResourceTypesEnum, int> PutInResourcesInStorage(Dictionary<ResourceTypesEnum, int> currentUnitResourcesDictionary)
    {
        var currentUnitResourcesDictionaryCopy = currentUnitResourcesDictionary.Keys.ToList();

        foreach (var resoruceKey in currentUnitResourcesDictionaryCopy)
        {
            int value = currentUnitResourcesDictionary[resoruceKey];
            PlayerResourceManager.instance.AddResource(resoruceKey, value);
            currentUnitResourcesDictionary[resoruceKey] = 0;
        }
        return currentUnitResourcesDictionary;
    }
}
