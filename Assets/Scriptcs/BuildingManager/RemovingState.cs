
using UnityEngine;

public class RemovingState : IBuildingState
{
    private int gameObjectIndex = -1;
    Grid grid;
    PreviewSystem previewSystem;
    GridData floorData;
    GridData buildingData;
    ObjectPlacer objectPlacer;

    public RemovingState(Grid grid,
                         PreviewSystem previewSystem,
                         GridData floorData,
                         GridData furnitureData,
                         ObjectPlacer objectPlacer)
    {

        this.grid = grid;
        this.previewSystem = previewSystem;
        this.floorData = floorData;
        this.buildingData = furnitureData;
        this.objectPlacer = objectPlacer;

        previewSystem.StartShowingRemovePreview();
    }

    public void EndState()
    {
        previewSystem.StopSchowingPreview();
    }

    public void OnAction(Vector3Int gridPosition)
    {

     
        GridData selectedData = null;
        if(buildingData.CanPlaceObjectAt(gridPosition, Vector2Int.one) == false)
        {
            selectedData = buildingData;
         
        }
        else if(floorData.CanPlaceObjectAt(gridPosition, Vector2Int.one) == false)
        {
            selectedData = floorData;
        }

        if(selectedData == null)
        {
            // SOUND
        }
        else
        {

            gameObjectIndex = selectedData.GetRepresentationIndex(gridPosition);


            if (gameObjectIndex == -1)
            {
              
                return;
            }

             //  selectedData.RemoveObjectAt(gridPosition);
        //   objectPlacer.RemoveObjectAt(gameObjectIndex);
        }
        Debug.Log(selectedData +  " -> " +gridPosition);
        Vector3 cellPosition = grid.CellToWorld(gridPosition);
        previewSystem.UpdatePosition(cellPosition, CheckIfSelectionIsValid(gridPosition));
    }

    private bool CheckIfSelectionIsValid(Vector3Int gridPosition)
    {
        return !(buildingData.CanPlaceObjectAt(gridPosition, Vector2Int.one) && floorData.CanPlaceObjectAt(gridPosition, Vector2Int.one));
    }

    public void UpdateState(Vector3Int gridPosition)
    {
        bool validity = CheckIfSelectionIsValid(gridPosition);
        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), validity);
    }
}
