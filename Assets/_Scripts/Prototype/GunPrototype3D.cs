using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPrototype3D : MonoBehaviour
{
    [SerializeField] private BulletPrototype3D _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private Transform _gizmosPoint;
    [SerializeField] private Transform _vector3Right;
    [SerializeField] private float _torque = 120f;

    private Rigidbody _rb;

    private void Awake() => _rb = GetComponent<Rigidbody>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            BulletPrototype3D _bullet = Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
            _bullet.SetVelOnInstantiate(_spawnPoint.forward);

            var dir = Vector3.Dot(_spawnPoint.forward, Vector3.right) < 0 ? Vector3.back : Vector3.forward;
            _rb.AddTorque(dir * _torque);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(_gizmosPoint.position,_gizmosPoint.position + (_spawnPoint.forward * 10));
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_vector3Right.position, _vector3Right.position + (Vector3.right * 10));
        
    }
}
