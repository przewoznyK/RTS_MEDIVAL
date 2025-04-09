using UnityEngine;
using UnityEngine.Rendering;

public class UnitClick : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    public LayerMask clickable;
    public LayerMask ground;

    //void Update()
    //{
    //    if(Input.GetMouseButtonDown(0))
    //    {
    //        RaycastHit hit;
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        // if we hit a clickable object
    //        if(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
    //        {
    //            // if we hit a clickable object
    //            if(Input.GetKey(KeyCode.LeftShift))
    //            {
    //                // shift clicked
    //              //  UnitSelections.Instance.ShiftClickSelect(hit.collider.gameObject);
    //            }
    //            else
    //            {
    //                // normal clicked
    //         //       UnitSelections.Instance.ClickSelect(hit.collider.gameObject);
    //            }
    //        }
    //        else
    //        {
    //            // if we didn't && we're not shift clicking
    //            if(!Input.GetKey(KeyCode.LeftShift))
    //            {
    //              //  UnitSelections.Instance.DeselectAll();
    //            }
                
    //        }
    //    }
    //}


}
