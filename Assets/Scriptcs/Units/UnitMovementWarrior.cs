using UnityEngine;

public class UnitMovementWarrior : UnitMovement
{
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && PreviewSystem.instance.isOnPreview == false && isActiveFromPlayerMouse)
        {
            SetUnitDestination();
        }
        if (targetAttackTransform != null)
        {
          
            UnitGoingToAttackTarget();
        }
    }
}
