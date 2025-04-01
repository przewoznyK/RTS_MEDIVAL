using UnityEngine;
using UnityEngine.EventSystems;

public class TownCenter : MonoBehaviour, IActivatable, IPointerClickHandler
{
    [SerializeField] private string buildingName;
    public void Activate()
    {
        this.enabled = true;
        Debug.Log("LEC");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("KLIKAM");
        
    }

    void OnMouseDown()
    {
        Debug.Log("Klikniêto obiekt!");
        UIManager.instance.ActiveBuildingPanel(buildingName);
    }
}
