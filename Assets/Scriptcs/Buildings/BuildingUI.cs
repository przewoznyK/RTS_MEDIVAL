using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    public static BuildingUI instance;
    [Header("Building")]
    [SerializeField] private Transform buildingPanel;
    [SerializeField] private TextMeshProUGUI buildingTitle;
    [SerializeField] private Transform meetingPoint;
    [Header("Units")]
    [SerializeField] private UnitsDatabaseSO unitsDatabase;
    [Header("Unit Buy Buttons")]
    [SerializeField] private Button[] unitBuyButton;
    private Transform currentSpawnPosition;
    private void Awake()
    {
        instance = this;
    }
    public void ActiveBuildingPanelAndPrepareButtons(ObjectData buildingData, UnitTypeEnum[] unitsToBuy, Transform spawnUnitPosition, Transform meetingPointPosition)
    {
        // Deative all buttons
        foreach (var button in unitBuyButton)
        {
            button.gameObject.SetActive(false);
        }
        // Set buttons
        for (int i = 0; i < unitsToBuy.Length; i++)
        {
            UnitStats unitStats = unitsDatabase.GetUnitStatsByUnitType(unitsToBuy[i]);
            Button currentButton = unitBuyButton[i];
            currentButton.gameObject.SetActive(true);

            currentButton.enabled = true;
            currentButton.GetComponent<ShopObject>().SetObjectToBuyIdAndRefreshButton(unitStats.ID);
            currentButton.image.sprite = unitStats.Sprite;
        }

        // Set and active building panel
        buildingTitle.text = buildingData.Name;
        buildingPanel.gameObject.SetActive(true);

        // Set spawnPoint and meeting position
        currentSpawnPosition = spawnUnitPosition;

        meetingPoint = meetingPointPosition;
        meetingPoint.gameObject.SetActive(true);
   
    }

    public void CloseBuildingPanel()
    {
        buildingPanel.gameObject.SetActive(false);
        meetingPoint.gameObject.SetActive(false);
    }
    public void StartBuyingUnitProcess(int unitID)
    {
        BuyingSystem.instance.BuyUnit(unitID, currentSpawnPosition, meetingPoint.transform);
    }
    public Transform ChangeMeetingPointPosition()
    {
        //Debug.Log("ZMIENIAM");
        //meetingPoint = position;
        //Debug.Log(meetingPoint.position);

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            meetingPoint.transform.position = hit.point;

            return meetingPoint;

        }
        return null;
    }

    public void SetNewMeetingPosition()
    {
        //  GameObject obj = Instantiate(meetingPoint);
        //   obj.transform.position = hit.point;




        //return null;
    }
}
