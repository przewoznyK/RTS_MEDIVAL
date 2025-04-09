using UnityEngine;

public class Building : MonoBehaviour, IActiveClickable
{
    [SerializeField] private int buildingID;
    [SerializeField] private UnitTypeEnum[] unitsToBuy;
    [SerializeField] private InputManager inputManager;
    Vector3 meetingPoint;
    ObjectData buildingData;

    private void Start()
    {
        buildingData = BuildingsDatabaseAccessById.instance.GetObjectDataByID(buildingID);
    }
    public void ActiveObject()
    {
        BuildingUI.instance.ActiveBuildingPanelAndPrepareButtons(buildingData, unitsToBuy, meetingPoint);
        inputManager.onClicked -= inputManager.ActiveClickableObject;
        inputManager.onClicked += ClosePanel;
        inputManager.onExit += SetMeetingPoint;
    }

    public void SetMeetingPoint()
    {
        meetingPoint = inputManager.GetSelectedMapPosition();
        BuildingUI.instance.ChangeMeetingPointPosition(meetingPoint);
    }



    public void ClosePanel()
    {
        if(!inputManager.IsPointerOverUI())
        {
            BuildingUI.instance.CloseBuildingPanel();
            inputManager.onClicked -= ClosePanel;
            inputManager.onClicked += inputManager.ActiveClickableObject;
        }
    }

    
}
