using UnityEngine;

public interface IPreviewSystem
{
    void StartShowingPlacementPreview(GameObject prefab, Vector2Int size);
    void StopSchowingPreview();
    void UpdatePosition(Vector3 position, bool validity);
}