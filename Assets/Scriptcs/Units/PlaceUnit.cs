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

    public void SpawnUnit(int id, Vector3 startPosition, Vector3 meetingPosition)
    {
        GameObject prefab = unitsDatabase.GetPrefabByID(id);
        if (prefab != null)
        {
            Instantiate(prefab, startPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Nie znaleziono jednostki o ID: " + id);
        }
    }
}
