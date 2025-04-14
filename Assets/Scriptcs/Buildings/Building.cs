using UnityEngine;

public class Building : MonoBehaviour, IActiveClickable
{
    [SerializeField] private int buildingID;
    [SerializeField] private UnitTypeEnum[] unitsToBuy;

    Vector3 meetingPoint;
    ObjectData buildingData;

    private void Start()
    {
        buildingData = BuildingsDatabaseAccessById.instance.GetObjectDataByID(buildingID);
    }
    public void ActiveObject()
    {
        BuildingUI.instance.ActiveBuildingPanelAndPrepareButtons(buildingData, unitsToBuy, meetingPoint);
        InputManager.instance.onClicked -= InputManager.instance.ActiveClickableObject;
        InputManager.instance.onClicked += ClosePanel;
        InputManager.instance.onExit += SetMeetingPoint;
    }

    public void SetMeetingPoint()
    {
        meetingPoint = InputManager.instance.GetSelectedMapPosition();
        BuildingUI.instance.ChangeMeetingPointPosition(meetingPoint);
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
