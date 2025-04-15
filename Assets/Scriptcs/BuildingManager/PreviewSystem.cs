using System.Collections;
using UnityEngine;

public class PreviewSystem : MonoBehaviour
{
    public static PreviewSystem instance;
    [SerializeField] private float previewYOffset = 0.06f;
    [SerializeField] private GameObject parentCursorIndicator;
    [SerializeField] private Renderer coursorIndicatorRenderer;
    private GameObject previewObject;

    [SerializeField] private Material previewMaterialPrefab;
    private Material previewMaterialInstance;

    public bool isOnPreview { get; private set; }

    private void Start()
    {
        instance = this;
        previewMaterialInstance = new Material(previewMaterialPrefab);
        parentCursorIndicator.SetActive(false);
    }

    public void StartShowingPlacementPreview(GameObject prefab, Vector2Int size)
    {
        CancelInvoke(nameof(TurnOffPreviewFlag));
        isOnPreview = true;
        previewObject = Instantiate(prefab);
        PreparePreview(previewObject);
        PrepareCursour(size);
        parentCursorIndicator.SetActive(true);
    }

    private void PreparePreview(GameObject previewObject)
    {
        Renderer[] renderers = previewObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer render in renderers)
        {

            Material[] materials = render.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = previewMaterialInstance;
            
            }
            render.materials = materials;
        }
    }

    private void PrepareCursour(Vector2Int size)
    {
    //    if (size.x > 0 || size.y > 0)
     //   {
         //   Vector3 newScale = new Vector3(size.x * coursorIndicatorRenderer.transform.localScale.y, coursorIndicatorRenderer.transform.localScale.y * size.y , coursorIndicatorRenderer.transform.localScale.z);
          //  coursorIndicatorRenderer.transform.localScale = newScale;
            //     cellIndicatorRenderer.material.mainTextureScale = size;
            //  cellIndicatorRenderer.material.SetTextureScale("_MainText", new Vector2(size.x, size.y));

      //  }


    }

    public void StopSchowingPreview()
    {
        Debug.Log("KONIEC");
        parentCursorIndicator.SetActive(false);
        if(previewObject != null)
            Destroy(previewObject);
        Invoke("TurnOffPreviewFlag", 0.5f);
    }
    void TurnOffPreviewFlag()
    {
        isOnPreview = false;
    }
    public void UpdatePosition(Vector3 position, bool validity)
    {
        if (previewObject != null)
        {
            MovePreview(position);
            ApplyFeedbackToPreview(validity);
        }


        MoveCursor(position);
        ApplyFeedbackToCursor(validity);
    }

    public void MovePreview(Vector3 position)
    {
        previewObject.transform.position = new Vector3(position.x, position.y + previewYOffset, position.z);
    }
    public void MoveCursor(Vector3 position)
    {
        parentCursorIndicator.transform.position = position;
    }
    public void ApplyFeedbackToPreview(bool validity)
    {
        Color c = validity ? Color.green : Color.red;
  
        c.a = 0.5f;
        previewMaterialInstance.color = c;
    }


    public void ApplyFeedbackToCursor(bool validity)
    {
        Color c = validity ? Color.green : Color.red;

        c.a = 0.5f;
        coursorIndicatorRenderer.material.color = c;
    }

    internal void StartShowingRemovePreview()
    {
        parentCursorIndicator.SetActive(true);
        PrepareCursour(Vector2Int.one);
        ApplyFeedbackToCursor(false);
    }

}
