using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Player Resource")]
    [SerializeField] private TextMeshProUGUI currentAmountWoodResourceTextUI;
    [SerializeField] private TextMeshProUGUI currentAmountStoneResourceTextUI;
    [Header("Shop")]
    [SerializeField] private ShopUI shopUI;
    [Header("Building")]
    [SerializeField] private Transform buildingPanel;
    [SerializeField] private TextMeshProUGUI buildingTitle;
    void Awake()
    {
        instance = this;


    }
    private void Start()
    {
        shopUI.RefreshShopButtons();
    }

    public void UpdateUICurrentAmountWoodResource(int newValue)
    {
        currentAmountWoodResourceTextUI.text = newValue.ToString();
    }
    public void UpdateUICurrentAmountStoneResource(int newValue)
    {
        currentAmountStoneResourceTextUI.text = newValue.ToString();
    }

    public void updateShopUI()
    {
        shopUI.RefreshShopButtons();
    }

    public void ActiveBuildingPanel(string buildingName)
    {
        buildingPanel.gameObject.SetActive(true);
        buildingTitle.text = buildingName;
    }
}
