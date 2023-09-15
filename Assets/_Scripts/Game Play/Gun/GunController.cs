using System;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private PolygonCollider2D _polygonCollider2D;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        _spriteRenderer.sprite = Inventory.InventoryItems[SelectionItems.IndexOfCurrentGun].Sprite;
        print(_spriteRenderer.sprite);
        _polygonCollider2D = gameObject.AddComponent<PolygonCollider2D>();
    }

    private void OnDestroy()
    {
        Destroy(_polygonCollider2D);
    }
}
