using System.Collections.Generic;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{
    public List<GameObject> unitList = new();
    public List<GameObject> unitsSelected = new();
    public  List<Unit> selectedUnitsTypeList = new();

    public static UnitSelections _instance;
    public static UnitSelections Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll();
        unitsSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        unitToAdd.GetComponent<IActiveClickable>().ActiveObject();
    }

    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }
        else
        {
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
            unitToAdd.GetComponent<UnitMovement>().enabled = false;
            unitsSelected.Remove(unitToAdd);
     
        }
    }
    public void DragSelect(GameObject unitToAdd)
    {
        if(!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }
    }

    public void DeselectAll()
    {
        foreach (var unit in unitsSelected)
        {
            unit.GetComponent<UnitMovement>().enabled = false;
            unit.transform.GetChild(0).gameObject.SetActive(false);
        }

        unitsSelected.Clear();
    }

    public List<Unit> GetSelectedUnitsType(UnitTypeEnum unitType)
    {
        selectedUnitsTypeList.Clear();
        foreach (var unit in unitsSelected)
        {
            Unit checkUnit = unit.GetComponent<Unit>();
            if (checkUnit.GetUnitType() == unitType)
            {
                selectedUnitsTypeList.Add(checkUnit);
            }
        }

        return selectedUnitsTypeList;
    }
}
