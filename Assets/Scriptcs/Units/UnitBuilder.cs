using UnityEngine;

public class UnitBuilder : Unit
{
    public override void ActiveObject()
    {
        unitMovement.enabled = true;
        UnitUI.instance.ActiveUnitPanelAndPrepareButtons(unitData);
        ShopUI.instance.SetActivePanel(true);
    }
}
