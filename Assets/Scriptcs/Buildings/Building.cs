using UnityEngine;

public class Building : MonoBehaviour, IActiveClickable
{
    [SerializeField] private int buildingID;
    [SerializeField] private UnitTypeEnum[] unitsToBuy;

    [SerializeField] Transform spawnUnitPoint;
    [SerializeField] Transform meetingUnitPoint;
    ObjectData buildingData;

    private void Start()
    {
        buildingData = BuildingsDatabaseAccessById.instance.GetObjectDataByID(buildingID);
    }
    public void ActiveObject()
    {

        BuildingUI.instance.ActiveBuildingPanelAndPrepareButtons(buildingData, unitsToBuy, spawnUnitPoint, meetingUnitPoint);
        InputManager.instance.onClicked -= InputManager.instance.ActiveClickableObject;
        InputManager.instance.onClicked += ClosePanel;
        InputManager.instance.onExit += SetMeetingPoint;
    }

    public void SetMeetingPoint()
    {
        spawnUnitPoint = InputManager.instance.GetSelectedMapTransform();
        BuildingUI.instance.ChangeMeetingPointPosition(meetingUnitPoint);
    }



    public void ClosePanel()
    {
        if(!InputManager.instance.IsPointerOverUI())
        {
            BuildingUI.instance.CloseBuildingPanel();
            InputManager.instance.onClicked -= ClosePanel;
            InputManager.instance.onClicked += InputManager.instance.ActiveClickableObject;
        }
    }

    
}
