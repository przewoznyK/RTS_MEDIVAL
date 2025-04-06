using UnityEngine;
using UnityEngine.EventSystems;

public class TownCenter : MonoBehaviour, IActivatable, IPointerClickHandler
{
    [SerializeField] private string buildingName;
    [SerializeField] private Vector3 startUnitPosition;
    [SerializeField] private UnitTypeEnum[] unitsToBuy;
    public void Activate()
    {
        this.enabled = true;
        Debug.Log("LEC");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("KLIKAM");
        
    }

    void OnMouseDown()
    {
        Debug.Log("Klikni�to obiekt!");
        BuildingUI.instance.ActiveBuildingPanelAndPrepareButtons(buildingName, unitsToBuy, startUnitPosition);

    }

    public void BuyUnit(int unitId)
    {
     //   PlaceUnit.instance.StartProcess(unitId, startUnitPosition);
    }

}
