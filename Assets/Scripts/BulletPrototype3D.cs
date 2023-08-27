using System;
using UnityEngine;

public class BulletPrototype3D : MonoBehaviour
{
    private Rigidbody _rb;
    
    [SerializeField] private float _bulletForce = 8f;

    private void Awake() => _rb = GetComponent<Rigidbody>();

    public void SetVelOnInstantiate(Vector3 dir)
    {
        _rb.velocity = dir * _bulletForce;
    }
}
