using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class ObjectsDatabaseSO : ScriptableObject
{
    public List<ObjectData> objectsData;


    public ObjectData GetBuildingDataByID(int id)
    {
        ObjectData buildingData = objectsData.FirstOrDefault(u => u.ID == id);
        return buildingData;
    }
}

[Serializable]
public class ObjectData
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public int ID { get; private set; }
    [field: SerializeField] public Vector2Int Size { get; private set; } = Vector2Int.one;
    [field: SerializeField] public GameObject Prefab { get; private set; }

    [field: SerializeField] public List<ObjectPrices> objectPrices = new List<ObjectPrices>();



}



[Serializable]
public class ObjectPrices
{
    [field: SerializeField] public ResourceTypesEnum priceType { get; private set; }
    [field: SerializeField] public int priceValue { get; private set; }
}



