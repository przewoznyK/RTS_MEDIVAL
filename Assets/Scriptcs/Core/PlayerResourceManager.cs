using System;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceTypesEnum
{
    none,
    wood,
    stone
}

[Serializable]
public class ResourceAmount
{
    public ResourceTypesEnum resourceType;
    public int amount;

    public ResourceAmount(ResourceTypesEnum type, int amt)
    {
        resourceType = type;
        amount = amt;
    }
}
public class PlayerResourceManager : MonoBehaviour
{
    public static PlayerResourceManager instance;
    [SerializeField] private List<ResourceAmount> resources = new List<ResourceAmount>();

    [SerializeField] private int currentAmountWoodResource;
    [SerializeField] private int currentAmountStoneResource;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        AddResource(ResourceTypesEnum.wood, 10);
        AddResource(ResourceTypesEnum.stone, 10);

        UpdateResourcesInUI(ResourceTypesEnum.wood, 10);
        UpdateResourcesInUI(ResourceTypesEnum.stone, 10);
    }


    public int GetResourceAmount(ResourceTypesEnum resourceType)
    {
        ResourceAmount resource = resources.Find(r => r.resourceType == resourceType);
        return resource != null ? resource.amount : 0;
    }

    public void AddResource(ResourceTypesEnum resourceType, int amount)
    {
        int valueToUpdateInUI;
        ResourceAmount resource = resources.Find(r => r.resourceType == resourceType);
        if (resource != null)
        {
            resource.amount += amount;
            valueToUpdateInUI = resource.amount;
        }
        else
        {
            resources.Add(new ResourceAmount(resourceType, amount));
            valueToUpdateInUI = amount;
        }
        UpdateResourcesInUI(resourceType, valueToUpdateInUI);
    }

    public bool SpendResource(ResourceTypesEnum resourceType, int amount)
    {
        ResourceAmount resource = resources.Find(r => r.resourceType == resourceType);
        if (resource != null && resource.amount >= amount)
        {
            resource.amount -= amount;
            UpdateResourcesInUI(resourceType, resource.amount);
            return true; // Uda³o siê odj¹æ surowce
 
        }
        return false; // Nie uda³o siê - brak zasobów
    }

    public bool CanPlayerHaveEnoughResource(ResourceTypesEnum resourceType, int amount)
    {
        ResourceAmount resource = resources.Find(r => r.resourceType == resourceType);
        if (resource != null && resource.amount >= amount)
        {
            return true; // Uda³o siê odj¹æ surowce
        }
        return false; // Nie uda³o siê - brak zasobów
    }

    void UpdateResourcesInUI(ResourceTypesEnum resourceType, int valueToUpdateInUI)
    {
        switch (resourceType)
        {
            case ResourceTypesEnum.wood:
                UIManager.instance.UpdateUICurrentAmountWoodResource(valueToUpdateInUI);
                break;
            case ResourceTypesEnum.stone:
                UIManager.instance.UpdateUICurrentAmountStoneResource(valueToUpdateInUI);
                break;
            default:
                break;
        }
    }
}
