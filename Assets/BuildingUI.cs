using TMPro;
using UnityEngine;

public class BuildingUI : MonoBehaviour
{
    public static BuildingUI instance;
    [Header("Building")]
    [SerializeField] private Transform buildingPanel;
    [SerializeField] private TextMeshProUGUI buildingTitle;


    private void Awake()
    {
        instance = this;
    }
    public void ActiveBuildingPanel(string buildingName)
    {
        buildingPanel.gameObject.SetActive(true);
        buildingTitle.text = buildingName;
    }
}
