using UnityEngine;
using UnityEngine.EventSystems;

public class TownCenter : MonoBehaviour
{
    [SerializeField] private string buildingName;
    [SerializeField] private Vector3 startUnitPosition;
    [SerializeField] private UnitTypeEnum[] unitsToBuy;

    void OnMouseDown()
    {
        Debug.Log("Klikniêto obiekt!");
    //    BuildingUI.instance.ActiveBuildingPanelAndPrepareButtons(buildingName, unitsToBuy, startUnitPosition);

    }

    public void BuyUnit(int unitId)
    {
     //   PlaceUnit.instance.StartProcess(unitId, startUnitPosition);
    }

}
