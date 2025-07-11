using UnityEngine;

public class UnitDrag : MonoBehaviour
{
    Camera myCam;

    // graphical
    [SerializeField]
    RectTransform boxVisual;

    // logical
    Rect selectionBox;

    Vector2 startPosition;
    Vector2 endPosition;
    void Start()
    {
        myCam = Camera.main;
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
        DrawVisual();
    }

    // Update is called once per frame
    void Update()
    {
        // when clicked
        if(Input.GetMouseButtonDown(0))
        {
            startPosition = Input.mousePosition;
            selectionBox = new Rect();
        }
        // when dragging
        if (Input.GetMouseButton(0))
        {
            endPosition = Input.mousePosition;
            DrawVisual();
            DrawSelection();
        }
        // when relase click
        if (Input.GetMouseButtonUp(0))
        {
            SelectUnits();
            startPosition = Vector2.zero;
            endPosition = Vector2.zero;
            DrawVisual();
        }
    }

    void DrawVisual()
    {
        Vector2 boxStart = startPosition;
        Vector2 boxEnd = endPosition;

        Vector2 boxCenter = (boxStart + boxEnd) / 2;
        boxVisual.position = boxCenter;

        Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));

        boxVisual.sizeDelta = boxSize;
    }

    void DrawSelection()
    {
        // do X calculations
        if(Input.mousePosition.x < startPosition.x)
        {
            // dragging left
            selectionBox.xMin = Input.mousePosition.x;
            selectionBox.xMax = startPosition.x;
        }
        else
        {
            // dragging right
            selectionBox.xMin = startPosition.x;
            selectionBox.xMax = Input.mousePosition.x;
        }

        // do Y calculations

        if(Input.mousePosition.y < startPosition.y)
        {
            // dragging down
            selectionBox.yMin = Input.mousePosition.y;
            selectionBox.yMax = startPosition.y;
        }
        else
        {
            // dragging up
            selectionBox.yMin = startPosition.y;
            selectionBox.yMax = Input.mousePosition.y;
        }
    }

    void SelectUnits()
    {
        // lopp thru all the units
        foreach (var unit in UnitSelections.Instance.unitList)
        {
            // if unit is within the bounds ofthe selection rect
            if(selectionBox.Contains(myCam.WorldToScreenPoint(unit.transform.position)))
            {
                // if any unit is within the selection add them to selection
                UnitSelections.Instance.DragSelect(unit);
            }
        }
    }
}
