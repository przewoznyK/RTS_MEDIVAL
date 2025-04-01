using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BuyingSystem : MonoBehaviour
{
    [SerializeField] private ObjectsDatabaseSO database;
    [SerializeField] private PlacementSystem placementSystem;
    int convertedToDatabaseId = -1;
    List<ObjectPrices> objectPrices;
    public void StartBuyingProcces(int objectId)
    {
        // Convert Value (in shop object count start on 1 beacuse 0 is reserved to floor)
        convertedToDatabaseId = objectId -= 1;

        if (database.objectsData.Count < convertedToDatabaseId)
            return; // Object doesnt exists in database

        if (CanPlayerBuyObject())
            placementSystem.StartPlacement(convertedToDatabaseId);
    }

    public bool CanPlayerBuyObject()
    {
        // Take price list
        objectPrices = database.objectsData[convertedToDatabaseId].objectPrices;

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

    internal void ResetSavedPrices()
    {
        convertedToDatabaseId = -1;
        objectPrices.Clear();
    }
}
