using UnityEngine;

public class UnitBuilder : Unit
{
    public override void ActiveObject()
    {
        unitMovement.enabled = true;
        UnitUI.instance.ActiveUnitPanelAndPrepareButtons(unitName);
        ShopUI.instance.SetActivePanel(true);
    }
}
