using UnityEngine;

public enum UnitTool
{
    axe,
    pickaxe,
    sword
}



[CreateAssetMenu(fileName = "UnitStatisitcsSO", menuName = "Scriptable Objects/UnitStatisitcsSO")]
public class UnitStatisitcsSO : ScriptableObject
{
    //public UnitTool unitTool { get; private set; }
    [SerializeField] private UnitTool unitTool;
    [SerializeField] private ResourceTypesEnum currentGatheringeResource;
    public UnitTool GetUnitToll()
    {
        return unitTool;
    }

    public ResourceTypesEnum GetCurrentGatheringeResource()
    {
        return currentGatheringeResource;
    }

    public void SetCurrentGatheringResource(ResourceTypesEnum newCurrentGatheringResource)
    {
        currentGatheringeResource = newCurrentGatheringResource;
    }
}
