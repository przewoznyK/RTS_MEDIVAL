using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public static ShopUI instance;
    [SerializeField] private Transform parentObject;
    private List<ShopObject> shopObjects = new List<ShopObject>();

    [Header("DescriptionPanel")]
    [SerializeField] private Transform descriptionPanel;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI priceText;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        LoadShopObjects();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RefreshShopButtons();
        }
    }

    private void LoadShopObjects()
    {
        shopObjects.Clear(); 

        foreach (Transform child in parentObject)
        {
            ShopObject shopItem = child.GetComponent<ShopObject>(); 
            if (shopItem != null)
            {
                shopObjects.Add(shopItem);
            }
        }
    }
    public void RefreshShopButtons()
    {
        foreach (var shopObject in shopObjects)
        {
            shopObject.RefreshPurchaseButton();
        } 
       
    }

    public void ShowObjectDescription(int objectId)
    {

        descriptionPanel.gameObject.SetActive(true);
        ObjectData objectData = BuyingSystem.instance.GetObjectData(objectId);
        titleText.text = objectData.Name;
        priceText.text = "";

        foreach (var priceData in objectData.objectPrices)
        {
            priceText.text += priceData.priceType.ToString();
            priceText.text += " ";
            priceText.text += priceData.priceValue.ToString();
            priceText.text += "\n";
        }
    }

    public void ClearPanelDescription()
    {
        titleText.text = "";
        priceText.text = "";
        descriptionPanel.gameObject.SetActive(false);
    }
}
