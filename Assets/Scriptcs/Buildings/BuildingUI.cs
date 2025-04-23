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
        Debug.Log(spawnUnitPosition);
        Debug.Log(meetingPointPosition);
        foreach (var button in unitBuyButton)
        {
            button.gameObject.SetActive(false);
        }
        for (int i = 0; i < unitsToBuy.Length; i++)
        {
            UnitStats unitStats = unitsDatabase.GetUnitStatsByUnitType(unitsToBuy[i]);
            Button currentButton = unitBuyButton[i];
            currentButton.gameObject.SetActive(true);

            currentButton.enabled = true;
            currentButton.GetComponent<ShopObject>().SetObjectToBuyIdAndRefreshButton(unitStats.ID);
            currentButton.image.sprite = unitStats.Sprite;
        }


        buildingTitle.text = buildingData.Name;
        buildingPanel.gameObject.SetActive(true);

        meetingPoint = meetingPointPosition;
        currentSpawnPosition = spawnUnitPosition;
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
    public void ChangeMeetingPointPosition(Transform position)
    {
        meetingPoint = position;
    }
}
