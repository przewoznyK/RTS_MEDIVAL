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

    private void Awake()
    {
        instance = this;
    }
    public void ActiveBuildingPanel(string buildingName)
    {
        buildingPanel.gameObject.SetActive(true);
        buildingTitle.text = buildingName;
    }

    public void ActiveBuyUnitButton(UnitTypeEnum[] units)
    {
        
        for (int i = 0; i < units.Length; i++)
        {
            UnitStats unitStats = unitsDatabase.GetUnitStatsByUnitType(units[i]);
            Button currentButton = unitBuyButton[i];

            currentButton.enabled = true;
            currentButton.image.sprite = unitStats.Sprite;
        }
    }
}
