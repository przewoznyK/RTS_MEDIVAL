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
            GameObject newUnit = Instantiate(prefab, startPosition, Quaternion.identity);
            newUnit.GetComponent<UnitMovement>().GoMeetingPosition(meetingPosition);
            UnitStats newUnitStats = unitsDatabase.GetUnitStatsByID(id);
            newUnit.GetComponent<Unit>().SetUnitName(newUnitStats.Name);
        }
        else
        {
            Debug.LogWarning("Nie znaleziono jednostki o ID: " + id);
        }
    }
}
