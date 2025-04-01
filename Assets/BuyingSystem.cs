using System;
using System.Collections.Generic;
using UnityEngine;

public class BuyingSystem : MonoBehaviour
{
    public static BuyingSystem instance;
    [SerializeField] private ObjectsDatabaseSO database;
    [SerializeField] private PlacementSystem placementSystem;
    int saveIdToEndPlaceObject = -1;

    List<ObjectPrices> objectPrices = new();

    private void Awake()
    {
        instance = this;

    }

    // Shop UI checking can player have enough resource to active buttons in shop
    public bool CanPlayerStartBuyObject(int objectId)
    {
        if (database.objectsData.Count < objectId - 1)
            return false; // Object doesnt exists in database


        // Take price list
        objectPrices = new List<ObjectPrices>(database.objectsData[objectId - 1].objectPrices);

        foreach (var price in objectPrices)
        {
            //  Debug.Log(price.priceType + "   " + price.priceValue);
            if (!PlayerResourceManager.instance.CanPlayerHaveEnoughResource(price.priceType, price.priceValue))
                return false;

        }
        return true;
    }

    // Player start preview object on grid 
    public void StartBuyingProcces(int objectId)
    {
        // Convert Value (in shop object count start on 1 beacuse 0 is reserved to floor)
        saveIdToEndPlaceObject = objectId -= 1;

        placementSystem.StartPlacement(saveIdToEndPlaceObject);
    }

    // One more time we check have enought resources to place object
    public bool CanPlayerPlaceCurrentObject()
    {
        if (database.objectsData.Count < saveIdToEndPlaceObject)
            return false; // Object doesnt exists in database


        // Take price list
        objectPrices = new List<ObjectPrices>(database.objectsData[saveIdToEndPlaceObject].objectPrices);

        foreach (var price in objectPrices)
        {
            //  Debug.Log(price.priceType + "   " + price.priceValue);
            if (!PlayerResourceManager.instance.CanPlayerHaveEnoughResource(price.priceType, price.priceValue))
                return false;

        }
        return true;
    }

    public void SpendResources()
    {
        foreach (var price in objectPrices)
        {
       //     Debug.Log(price.priceType + "   " + price.priceValue);
            if (!PlayerResourceManager.instance.SpendResource(price.priceType, price.priceValue));

        }
    }
    public ObjectData GetObjectData(int objectId)
    {
        return database.objectsData[objectId - 1];
    }
}
