using System;
using UnityEngine;

public class PlaceUnit : MonoBehaviour
{
    public static PlaceUnit instance;
    [SerializeField] private UnitsDatabaseSO unitsDatabase;
    private void Awake()
    {
        instance = this;
    }
    internal void StartProcess(int objectId, Vector3 position)
    {
        SpawnUnit(objectId, position);
    }

    public void SpawnUnit(int id, Vector3 position)
    {
        GameObject prefab = unitsDatabase.GetPrefabByID(id);
        if (prefab != null)
        {
            Instantiate(prefab, position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Nie znaleziono jednostki o ID: " + id);
        }
    }
}
