using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
    public static BuildingUI instance;
    [Header("Building")]
    [SerializeField] private Transform buildingPanel;
    [SerializeField] private TextMeshProUGUI buildingTitle;
    [Header("Units")]
    [SerializeField] private UnitsDatabaseSO unitsDatabase;
    [Header("Unit Buy Buttons")]
    [SerializeField] private Button[] unitBuyButton;
    [SerializeField] private Vector3 currentStartUnitPosition;
    private void Awake()
    {
        instance = this;
    }
    public void ActiveBuildingPanelAndPrepareButtons(string buildingName, UnitTypeEnum[] units, Vector3 startUnitPosition)
    {
        
        for (int i = 0; i < units.Length; i++)
        {
            UnitStats unitStats = unitsDatabase.GetUnitStatsByUnitType(units[i]);
            Button currentButton = unitBuyButton[i];


            currentButton.enabled = true;
            currentButton.GetComponent<ShopObject>().SetObjectToBuyIdAndRefreshButton(unitStats.ID);
            currentButton.image.sprite = unitStats.Sprite;
        }

     
        buildingTitle.text = buildingName;
        buildingPanel.gameObject.SetActive(true);
        currentStartUnitPosition = startUnitPosition;
    }

    public void StartBuyingUnitProcess(int unitID)
    {
        BuyingSystem.instance.BuyUnit(unitID, currentStartUnitPosition);
    }
    
}
