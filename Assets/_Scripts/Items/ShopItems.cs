using System.Collections.Generic;
using UnityEngine;
using System;

public class ShopItems : MonoBehaviour
{
    public static Action<Item> OnUnlockingItem;
    
    [field: SerializeField] public List<Item> ListUnlockItems { get; private set; } = new();

    [SerializeField] private GameObject _placeHolder;
    [SerializeField] private GameObject _prefabTemplete;

    private void Awake()
    {
        foreach (var unlockItem in ListUnlockItems)
        {
            TempleteItem templeteItem = Instantiate(_prefabTemplete, _placeHolder.transform).GetComponent<TempleteItem>();
            templeteItem.AssignData(unlockItem, this);
        }
    }

    public void UnlockItem(Item item)
    {
        if (!ListUnlockItems.Contains(item)) return;
        
        ListUnlockItems.Remove(item);
        
        OnUnlockingItem?.Invoke(item);
    }
}
