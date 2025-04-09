
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image image;
    [SerializeField] private Button button;
    [SerializeField] private int id;
    [SerializeField] private bool isUnit;
    private void Start()
    {
        ShopUI.instance.shopObjectsList.Add(this);
    }
    public void RefreshPurchaseButton()
    {
        bool canBuy;
        if(isUnit)
            canBuy = BuyingSystem.instance.CanPlayerStartBuyUnit(id);
        else
            canBuy = BuyingSystem.instance.CanPlayerStartBuyBuilding(id);
        if(canBuy)
        {
            button.enabled = true;
            image.color = Color.green;
        }
        else
        {
            button.enabled = false;
            image.color = Color.red;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(isUnit)
            ShopUI.instance.ShowUnitDescription(id);
        else
            ShopUI.instance.ShowBuildingDescription(id);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ShopUI.instance.ClearPanelDescription();
    }

    public void SetObjectToBuyIdAndRefreshButton(int value)
    {
        id = value;
        button.onClick.RemoveAllListeners(); // (opcjonalne) wyczyœæ poprzednie, jeœli trzeba
        button.onClick.AddListener(() => BuildingUI.instance.StartBuyingUnitProcess(id));


        RefreshPurchaseButton();
    }
}
