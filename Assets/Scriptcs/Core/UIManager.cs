using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Player Resource")]
    [SerializeField] private TextMeshProUGUI currentAmountWoodResourceTextUI;
    [SerializeField] private TextMeshProUGUI currentAmountStoneResourceTextUI;
    [SerializeField] private TextMeshProUGUI currentAmountFoodResourceTextUI;
    [SerializeField] private TextMeshProUGUI currentAmountGoldResourceTextUI;
    [Header("Shop")]
    [SerializeField] private ShopUI shopUI;

    void Awake()
    {
        instance = this;
    }

    public void UpdateUICurrentAmountWoodResource(int newValue)
    {
        currentAmountWoodResourceTextUI.text = newValue.ToString();
    }
    public void UpdateUICurrentAmountStoneResource(int newValue)
    {
        currentAmountStoneResourceTextUI.text = newValue.ToString();
    }
    public void UpdateUICurrentAmountFoodResource(int newValue)
    {
        currentAmountFoodResourceTextUI.text = newValue.ToString();
    }
    public void UpdateUICurrentAmountGoldResource(int newValue)
    {
        currentAmountGoldResourceTextUI.text = newValue.ToString();
    }


}
