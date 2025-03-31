//using UnityEngine;
//using UnityEngine.UI;

//public class RTSController : MonoBehaviour
//{
//    [SerializeField] private RectTransform selectionBox;
//    private Vector2 startSelectionBoxPos;
//    void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            SelectUnitWithLeftMouseButton();
//            SelectionBox();
//        }
//    }

//    void SelectUnitWithLeftMouseButton()
//    {
//        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//        if (Physics.Raycast(ray, out RaycastHit hit))
//        {
//            if (hit.collider.CompareTag("Unit1"))
//            {
//                hit.collider.GetComponent<Unit>().ActiveUnit();
//            }

//        }
//    }

//    void SelectionBox()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            startSelectionBoxPos = Input.mousePosition;
//            selectionBox.gameObject.SetActive(true);
//        }

//        if (Input.GetMouseButton(0))
//        {
//            Vector2 currentPos = Input.mousePosition;
//            UpdateSelectionBox(startSelectionBoxPos, currentPos);
//        }

//        if (Input.GetMouseButtonUp(0))
//        {
//            selectionBox.gameObject.SetActive(false);
//            SelectUnits();
//        }
//    }

//    void UpdateSelectionBox(Vector2 start, Vector2 end)
//    {
//        Vector2 size = new Vector2(Mathf.Abs(end.x - start.x), Mathf.Abs(end.y - start.y));
//        Vector2 center = (start + end) / 2f;

//        selectionBox.sizeDelta = size;
//        selectionBox.position = center;
//    }

//    void SelectUnits()
//    {
//        Vector2 min = selectionBox.anchoredPosition - (selectionBox.sizeDelta / 2);
//        Vector2 max = selectionBox.anchoredPosition + (selectionBox.sizeDelta / 2);

//        foreach (Unit unit in FindObjectsOfType<Unit>())
//        {
//            Vector2 screenPos = Camera.main.WorldToScreenPoint(unit.transform.position);

//            if (screenPos.x > min.x && screenPos.x < max.x &&
//                screenPos.y > min.y && screenPos.y < max.y)
//            {
//                unit.ActiveUnit();  // Zaznaczamy jednostkê
//            }
//            else
//            {
//                unit.DeactiveUnit(); // Odznaczamy, jeœli poza boxem
//            }
//        }
//    }
//}
