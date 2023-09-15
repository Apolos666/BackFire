using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TempleteItem : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _name;
    private ShopItems _shopItems;
    private Item _item;

    public void AssignData(Item item, ShopItems shopItems)
    {
        _image.sprite = item.Sprite;
        _name.text = item.name;
        _shopItems = shopItems;
        _item = item;
    }

    public void UnlockButton()
    {
        _shopItems.UnlockItem(_item);
        gameObject.SetActive(false);
    }
}
