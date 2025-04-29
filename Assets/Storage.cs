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


}
