using System;
using UnityEngine;

public class GunPrototype : MonoBehaviour
{
    [SerializeField] private BulletPrototype _bullet;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _forceAmount = 600f;
    [SerializeField] private float _maxVelocity = 15f;
    [SerializeField] private float _maxForceBonus = 900f;
    [SerializeField] private float _torqueSpeed = 120f;
    [SerializeField] private float _maxTorqueBonus = 150f;
    [SerializeField] private float _maxAngularVelocity = 250f;
    [SerializeField] private float _maxY = 10f;
    [SerializeField] private float _maxUpAssist = 30f;

    [SerializeField] private Transform _Vector2up;

    [SerializeField] private VoidEventChannelSO _OnPlayerDeath;
    
    private Rigidbody2D _rb;
    private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _OnPlayerDeath.OnChangedRequest += DisableGunPlay;
        PauseMenuState.OnEnterEvent += PauseMenuStateOnEnterEvent;
        PauseMenuState.OnExitEvent += PauseMenuStateOnExitEvent;
    }

    private void OnDestroy()
    {
        _OnPlayerDeath.OnChangedRequest -= DisableGunPlay;
        PauseMenuState.OnEnterEvent -= PauseMenuStateOnEnterEvent;
        PauseMenuState.OnExitEvent -= PauseMenuStateOnExitEvent;
    }

    private void PauseMenuStateOnExitEvent()
    {
        Time.timeScale = 1;
    }

    private void PauseMenuStateOnEnterEvent()
    {
        Time.timeScale = 0;
    }

    private void DisableGunPlay()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        _rb.angularVelocity = Mathf.Clamp(_rb.angularVelocity, -_maxAngularVelocity, _maxAngularVelocity);
        _rb.velocity = new Vector2(Mathf.Clamp(_rb.velocity.x, -_maxVelocity, _maxVelocity), Mathf.Clamp(_rb.velocity.y, -_maxVelocity, _maxVelocity));
        
        if (Input.touchCount > 0)
        {
            // Lấy thông tin về cảm ứng đầu tiên
            Touch touch = Input.GetTouch(0);

            // Kiểm tra loại sự kiện cảm ứng
            if (touch.phase == TouchPhase.Began)
            {
                // Xử lý sự kiện khi người dùng chạm vào màn hình
                Debug.Log("Chạm vào màn hình!");
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            _animator.Play("Shoot");
            // Khởi tạo đối tượng và truyền hướng cho nó
            var bullet = Instantiate(_bullet, _spawnPoint.position, _spawnPoint.rotation);
            bullet.SetVelOnInstantiate(_spawnPoint.right);
            
            // Dựa vào velocity hiện tại để áp dụng 1 lượng lực đủ khi quay chiều
            float forcePointRight = Mathf.InverseLerp(0, _maxVelocity, Mathf.Abs(_rb.velocity.x));
            float forceBounsRight = Mathf.Lerp(0, _maxForceBonus, forcePointRight);
            // Dựa vào vị trí y hiện tại để áp dụng 1 lượng lực đủ lớn để đẩy vật lên
            float forcePointUp = Mathf.InverseLerp(0, _maxY, transform.position.y);
            float forceBonusUp = Mathf.Lerp(_maxUpAssist, 0, forcePointUp);
            var forceDir = -transform.right * (_forceAmount + forceBounsRight)  + Vector3.up * forceBonusUp;
            if (_rb.position.y > _maxY) forceDir.y = Mathf.Min(0, forceDir.y);
            _rb.AddForce(forceDir);

            // Dựa vào lực torque hiện tại để tính lượng thêm bonus thêm vào, từ đó có đủ lực khi chuyển hướng
            float torquePoint = Mathf.InverseLerp(0, _maxAngularVelocity, MathF.Abs(_rb.angularVelocity));
            float torqueBonus = Mathf.Lerp(0, _maxTorqueBonus, torquePoint);
            float torque = _torqueSpeed + torqueBonus;
            
            // Xác định hướng quay của súng
            var dir = Vector2.Dot(Vector2.right, _spawnPoint.right) < 0 ? -1f : 1f;
            _rb.AddTorque(dir * torque);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(_Vector2up.position, _Vector2up.position + (Vector3.right * 10));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(_spawnPoint.position, _spawnPoint.position + (_spawnPoint.right * 10));
    }
}
