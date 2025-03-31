using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Player Resource")]
    [SerializeField] private TextMeshProUGUI currentAmountWoodResourceTextUI;
    [SerializeField] private TextMeshProUGUI currentAmountStoneResourceTextUI;
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


}
