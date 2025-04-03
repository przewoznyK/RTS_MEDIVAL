using UnityEngine;
using UnityEngine.EventSystems;

public class TownCenter : MonoBehaviour, IActivatable, IPointerClickHandler
{
    [SerializeField] private string buildingName;
    [SerializeField] private Vector3 startUnitPosition;
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
        Debug.Log("Klikniêto obiekt!");
        BuildingUI.instance.ActiveBuildingPanel(buildingName);
    }

    public void BuyUnit(int unitId)
    {
        PlaceUnit.instance.StartProcess(unitId, startUnitPosition);
    }

}
