using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image image;
    [SerializeField] private Button button;
    [SerializeField] private int id;

    public void RefreshPurchaseButton()
    {
        bool canBuy;
        canBuy = BuyingSystem.instance.CanPlayerStartBuyObject(id);
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
        ShopUI.instance.ShowObjectDescription(id);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ShopUI.instance.ClearPanelDescription();
    }
}
