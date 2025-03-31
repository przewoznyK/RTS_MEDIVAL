using UnityEngine;

public enum UnitTool
{
    axe,
    pickaxe,
    sword
}

public enum CurrentGatheringeResource
{ 
    none,
    wood,
    stone
}


[CreateAssetMenu(fileName = "UnitStatisitcsSO", menuName = "Scriptable Objects/UnitStatisitcsSO")]
public class UnitStatisitcsSO : ScriptableObject
{
    //public UnitTool unitTool { get; private set; }
    [SerializeField] private UnitTool unitTool;
    [SerializeField] private CurrentGatheringeResource currentGatheringeResource;
    public UnitTool GetUnitToll()
    {
        return unitTool;
    }

    public CurrentGatheringeResource GetCurrentGatheringeResource()
    {
        return currentGatheringeResource;
    }

    public void SetCurrentGatheringResource(CurrentGatheringeResource newCurrentGatheringResource)
    {
        currentGatheringeResource = newCurrentGatheringResource;
    }
}
