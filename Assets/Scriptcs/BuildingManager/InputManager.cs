using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    private Vector3 lastPosition;

    [SerializeField] private LayerMask placementLayermask;
    [SerializeField] private LayerMask clickable;
    public event Action onClicked, onExit;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        onClicked += ActiveClickableObject;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            onClicked?.Invoke();
        }
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1))
        {
            onExit?.Invoke();
        }
    }

    public bool IsPointerOverUI()
        => EventSystem.current.IsPointerOverGameObject();
    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100, placementLayermask))
        {
            lastPosition = hit.point;
        }
        return lastPosition;
    }

    public void ActiveClickableObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        ShopUI.instance.SetActivePanel(false);
        UnitUI.instance.CloseUnitPanel();
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, clickable))
        {
            // Building
            if (hit.collider.gameObject.CompareTag("Building"))
            {
                UnitUI.instance.CloseUnitPanel();
                hit.collider.GetComponent<IActiveClickable>().ActiveObject();
            }
            // Unit
            else
            {
                // if we hit a clickable object
                if (Input.GetKey(KeyCode.LeftShift))
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
        }
        else
        {
            // if we didn't && we're not shift clicking
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                  UnitSelections.Instance.DeselectAll();
            }

        }
    }

}
