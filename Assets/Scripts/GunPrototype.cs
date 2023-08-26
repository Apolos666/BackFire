using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GunPrototype : MonoBehaviour
{
    [Header("Prefabs")] 
    [Space(10)] 
    
    [SerializeField] private BulletPrototype _bullet;

    [Header("Gun Settings")] 
    [Space(10)] 
    
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _forceAmount = 600f;
    [SerializeField] private float _torqueSpeed = 120f;
    [SerializeField] private float _maxTorqueBonus = 150f;
    [SerializeField] private float _maxAngularVelocity = 160f;
    [SerializeField] private float _maxY = 10f;
    [SerializeField] private float _maxUpAssist = 30f;

    private Rigidbody2D _rb;
    private Rigidbody _rb3D;

    private void Awake() => _rb = GetComponent<Rigidbody2D>();

    private void Update()
    {
        _rb.angularVelocity = Mathf.Clamp(_rb.angularVelocity, -_maxAngularVelocity, _maxAngularVelocity);
        
        if (Input.GetMouseButtonDown(0))
        {
            // Khởi tạo đối tượng và truyền hướng cho nó
            var bullet = Instantiate(_bullet, _spawnPoint.position, _spawnPoint.rotation);
            bullet.SetVelOnInstantiate(_spawnPoint.right);

            // Tạo lực đẩy và xác định lượng lực hỗ trợ đẩy lên tuỳ thuộc vào độ cao
            var assistPoint = Mathf.InverseLerp(0, _maxY, _rb.position.y);
            var assistAmount = Mathf.Lerp(_maxUpAssist, 0, assistPoint);
            var forceDir = -transform.right * _forceAmount + Vector3.up * assistAmount;
            print(forceDir);
            if (_rb.position.y > _maxY) forceDir.y = Mathf.Min(0, forceDir.y);
            _rb.AddForce(forceDir);
            
            // Xác định lượng lực tiếp theo truyền cho nó quay
            var angularPoint = Mathf.InverseLerp(0, _maxAngularVelocity, Mathf.Abs(_rb.angularVelocity));
            var amount = Mathf.Lerp(0, _maxTorqueBonus, angularPoint);
            var torque = _torqueSpeed + amount;
            
            // Xác định hướng quay của súng
            var torqueApply = Vector2.Dot(_spawnPoint.up, Vector3.right) < 0 ? -torque : torque;
            _rb.AddTorque(torqueApply);
        }
    }
}
