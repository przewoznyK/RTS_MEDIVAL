using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public static ShopUI instance;
    [SerializeField] private Transform parentObject;
    public List<ShopObject> shopObjectsList = new List<ShopObject>();

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
        //shopObjectsList.Clear(); 

        //foreach (Transform child in parentObject)
        //{
        //    ShopObject shopItem = child.GetComponent<ShopObject>(); 
        //    if (shopItem != null)
        //    {
        //        shopObjectsList.Add(shopItem);
        //    }
        //}
    }

    public void AddShopObjectToList(ShopObject newShopObject)
    {
        shopObjectsList.Add(newShopObject);
    }
    public void RefreshShopButtons()
    {
        foreach (var shopObject in shopObjectsList)
        {
            shopObject.RefreshPurchaseButton();
        } 
       
    }

    public void ShowBuildingDescription(int objectId)
    {

        descriptionPanel.gameObject.SetActive(true);
        ObjectData objectData = BuyingSystem.instance.GetBuildingData(objectId);
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
    public void ShowUnitDescription(int objectId)
    {

        descriptionPanel.gameObject.SetActive(true);
        UnitStats unitStats = BuyingSystem.instance.GetUnitStats(objectId);
        titleText.text = unitStats.Name;
        priceText.text = "";

        foreach (var priceData in unitStats.objectPrices)
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
