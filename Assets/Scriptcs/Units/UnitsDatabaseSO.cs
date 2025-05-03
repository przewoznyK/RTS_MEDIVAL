using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum UnitTypeEnum
{
    warrior,
    lumberjack,
    miner,
    builder
}




[CreateAssetMenu(fileName = "UnitsDatabaseSO", menuName = "Scriptable Objects/UnitsDatabaseSO")]
public class UnitsDatabaseSO : ScriptableObject
{
    public List<UnitStats> unitsData;

    public GameObject GetPrefabByID(int id)
    {
        UnitStats unit = unitsData.FirstOrDefault(u => u.ID == id);
        return unit?.Prefab;
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
    [field: SerializeField] public int maxHealth { get; private set; }
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



