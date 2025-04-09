using UnityEngine;

public class BuildingsDatabaseAccessById : MonoBehaviour
{
    public static BuildingsDatabaseAccessById instance;
    [SerializeField] private ObjectsDatabaseSO buildingsDatabase;
    private void Awake()
    {
        instance = this;
    }

    public ObjectData GetObjectDataByID(int id)
    {
        return buildingsDatabase.GetBuildingDataByID(id);
    }
}
