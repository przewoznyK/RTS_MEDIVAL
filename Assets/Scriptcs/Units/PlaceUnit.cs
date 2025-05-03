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

    public void SpawnUnit(int id, Transform spawnPosition, Transform meetingPosition)
    {
        GameObject prefab = unitsDatabase.GetPrefabByID(id);
        if (prefab != null)
        {
            GameObject newUnit = Instantiate(prefab, spawnPosition.position, Quaternion.identity);
            newUnit.GetComponent<UnitMovement>().GoMeetingPosition(meetingPosition);
            UnitStats newUnitStats = unitsDatabase.GetUnitStatsByID(id);
            newUnit.GetComponent<Unit>().SetUnitStats(newUnitStats);
        }
    }
}
