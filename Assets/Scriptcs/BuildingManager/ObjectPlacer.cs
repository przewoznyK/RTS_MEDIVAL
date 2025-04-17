using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField] private UnitSelections unitSelections;
    [SerializeField] private List<GameObject> placedGameObject = new();
    [SerializeField] private GameObject buildingQuad;

    public int PlaceObject(GameObject prefab, Vector3 position)
    {

        GameObject newObject = Instantiate(buildingQuad);
        newObject.transform.position = position;
        newObject.GetComponent<BuildingToBulit>().SetFinishBuilding(prefab);
        List<Unit> selectedUnits = unitSelections.GetSelectedUnitsType(UnitTypeEnum.builder);
        foreach (var unit in selectedUnits)
        {
            unit.GetComponent<UnitMovementBuilder>().GoBuildingObject(newObject);
        }
        //GameObject newObject = Instantiate(prefab);
        //newObject.transform.position = position;
        //if (newObject.TryGetComponent<IActivatable>(out IActivatable activeScript))
        //    activeScript.Activate();

        //placedGameObject.Add(newObject);
        return placedGameObject.Count - 1;
    }

    internal void RemoveObjectAt(int gameObjectIndex)
    {
        if(placedGameObject.Count <= gameObjectIndex || placedGameObject[gameObjectIndex] == null)
        {
            return;
        }
        Destroy(placedGameObject[gameObjectIndex]);
        placedGameObject[gameObjectIndex] = null;
    }
}
