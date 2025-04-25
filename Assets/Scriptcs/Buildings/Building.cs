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
        Debug.Log(meetingUnitPoint.transform.position);
        BuildingUI.instance.ActiveBuildingPanelAndPrepareButtons(buildingData, unitsToBuy, spawnUnitPoint, meetingUnitPoint);
        InputManager.instance.onClicked -= InputManager.instance.ActiveClickableObject;
        InputManager.instance.onClicked += ClosePanel;
        InputManager.instance.onExit += SetMeetingPoint;
    }

    public void SetMeetingPoint()
    {
        //  meetingUnitPoint = InputManager.instance.GetSelectedMapTransform();
        Debug.Log("ZMIENIAM");
        meetingUnitPoint.transform.position =  BuildingUI.instance.ChangeMeetingPointPosition().transform.position;
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
