using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum UnitTypeEnum
{
    lumberjack,
    miner,
    builder,
    warrior
}




[CreateAssetMenu(fileName = "UnitsDatabaseSO", menuName = "Scriptable Objects/UnitsDatabaseSO")]
public class UnitsDatabaseSO : ScriptableObject
{
    public List<UnitStats> unitsData;

    public GameObject GetPrefabByID(int id)
    {
        UnitStats unit = unitsData.FirstOrDefault(u => u.ID == id);
        return unit?.Prefab; // Jeœli znajdzie, zwróci Prefab, jeœli nie, zwróci null.
    }

    public UnitStats GetUnitStatsByID(int id)
    {
        UnitStats unit = unitsData.FirstOrDefault(u => u.ID == id);
        return unit;
    }

    public UnitStats GetUnitStatsByUnitType(UnitTypeEnum unitType)
    {
        UnitStats unit = unitsData.FirstOrDefault(u => u.unitType == unitType);
        return unit;
    }
}

[Serializable]
public class UnitStats
{
    [field: SerializeField] public int ID { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public UnitTypeEnum unitType { get; private set; }
    [field: SerializeField] public GameObject Prefab { get; private set; }
    [field: SerializeField] public Sprite Sprite { get; private set; }

    [field: SerializeField] public List<ObjectPrices> objectPrices = new List<ObjectPrices>();

    internal ResourceTypesEnum GetCurrentGatheringeResource()
    {
        throw new NotImplementedException();
    }

    internal UnitTypeEnum GetUnitType()
    {
        throw new NotImplementedException();
    }

    internal void SetCurrentGatheringResource(ResourceTypesEnum newCurrentGatheringResource)
    {
        throw new NotImplementedException();
    }
}

//[CreateAssetMenu(fileName = "UnitStatisitcSO", menuName = "Scriptable Objects/UnitStatisitcsSO")]
//public class UnitStatisitcSO : ScriptableObject
//{
//    //public UnitTool unitTool { get; private set; }
//    [field: SerializeField] private UnitTypeEnum unitType;
//    [field: SerializeField] private ResourceTypesEnum currentGatheringeResource;
//    [field: SerializeField] public List<ObjectPrices> objectPrices = new List<ObjectPrices>();
//    public UnitTypeEnum GetUnitType()
//    {
//        return unitType;
//    }

//    public ResourceTypesEnum GetCurrentGatheringeResource()
//    {
//        return currentGatheringeResource;
//    }

//    public void SetCurrentGatheringResource(ResourceTypesEnum newCurrentGatheringResource)
//    {
//        currentGatheringeResource = newCurrentGatheringResource;
//    }
//}

//[CreateAssetMenu]
//public class ObjectsDatabaseSO : ScriptableObject
//{
//    public List<ObjectData> objectsData;
//}



