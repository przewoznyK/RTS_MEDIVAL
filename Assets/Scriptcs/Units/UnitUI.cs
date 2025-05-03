using TMPro;
using UnityEngine;

public class UnitUI : MonoBehaviour
{
    public static UnitUI instance;
    [Header("Unit")]
    [SerializeField] private Transform unitPanel;
    [SerializeField] private TextMeshProUGUI unitTitle;
    [SerializeField] private TextMeshProUGUI unitHealth;

    private void Awake()
    {
        instance = this;
    }

    public void ActiveUnitPanelAndPrepareButtons(UnitRuntimeData unitData)
    {
        
        if(unitData.Name != null)
            unitTitle.text = unitData.Name;
        else
            unitTitle.text = "NULL";
        unitHealth.text = unitData.currentHealth + "/" + unitData.maxHealth;
        unitPanel.gameObject.SetActive(true);
    }

    public void CloseUnitPanel()
    {
        unitPanel.gameObject.SetActive(false);
    }
}
