using UnityEngine;
using UnityEngine.Rendering;

public class UnitClick : MonoBehaviour
{
    private Camera myCam;

    public LayerMask clickable;
    public LayerMask ground;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myCam = Camera.main;        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);
            // if we hit a clickable object
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            {
                // if we hit a clickable object
                if(Input.GetKey(KeyCode.LeftShift))
                {
                    // shift clicked
                    UnitSelections.Instance.ShiftClickSelect(hit.collider.gameObject);
                }
                else
                {
                    // normal clicked
                    UnitSelections.Instance.ClickSelect(hit.collider.gameObject);
                }
            }
            else
            {
                // if we didn't && we're not shift clicking
                if(!Input.GetKey(KeyCode.LeftShift))
                {
                    UnitSelections.Instance.DeselectAll();
                }
                
            }
        }
    }
}
