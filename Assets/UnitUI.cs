using TMPro;
using UnityEngine;

public class UnitUI : MonoBehaviour
{
    public static UnitUI instance;
    [Header("Unit")]
    [SerializeField] private Transform unitPanel;
    [SerializeField] private TextMeshProUGUI unitTitle;
    //[Header("Units")]
    //[SerializeField] private UnitsDatabaseSO unitsDatabase;
    //[Header("Unit Buy Buttons")]
    //[SerializeField] private Button[] unitBuyButton;
    //[SerializeField] private Vector3 currentStartUnitPosition;

    private void Awake()
    {
        instance = this;
    }

    public void ActiveUnitPanelAndPrepareButtons(string unitName)
    {
        if(unitName != null)
            unitTitle.text = unitName;
        else
            unitTitle.text = "NULL";
        unitPanel.gameObject.SetActive(true);
    }

    public void CloseUnitPanel()
    {
        unitPanel.gameObject.SetActive(false);
    }
}
