using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Item _initItem;
    
    public static List<Item> InventoryItems = new();
    public static Action OnChangedInventory;

    private void Awake()
    {
        AddItem(_initItem);
    }

    private void OnEnable()
    {
        ShopItems.OnUnlockingItem += AddItem;
    }

    private void OnDisable()
    {
        ShopItems.OnUnlockingItem -= AddItem;
    }

    private void AddItem(Item item)
    {
        InventoryItems.Add(item);
        OnChangedInventory?.Invoke();
    }
}
