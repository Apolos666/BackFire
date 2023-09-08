using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class BulletPrototype : MonoBehaviour
{
    [Header("Bullet Settings")]
    [Space(10)]
    [SerializeField] private float _bulletSpeed;
    
    private Rigidbody2D _rb;

    private void Awake() => _rb = GetComponent<Rigidbody2D>();

    public void SetVelOnInstantiate(Vector2 dir)
    {
        _rb.velocity = dir * _bulletSpeed;
    }
}
