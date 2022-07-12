using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class BulletShot : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _cooldown;
    [SerializeField] private Transform _shootingPosition;
    public List<KeyCode> ShotKeys = new List<KeyCode>() {KeyCode.Space, KeyCode.Mouse0 };
    [SerializeField] private ObjectPool _objectPool; 
    [SerializeField] private UnityEvent _shot;

    private float _tempCooldown;
    private bool _isCooldownDecreases;

    public float TempCooldown => _tempCooldown;
    public bool IsCooldownDecreases => _isCooldownDecreases;

    public void SetTempCooldown(float tempCooldown)
    {
        _tempCooldown = tempCooldown;
    }

    public void SetIsCooldownDecreases(bool isCooldownDecreases)
    {
        _isCooldownDecreases = isCooldownDecreases;
    }

    private void Shoot()
    {
        //Bullet bullet = Instantiate(_bulletPrefab, _shootingPosition.position, transform.rotation);
        Bullet bullet = _objectPool.GetPooledBullet().GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.gameObject.SetActive(true);

            bullet.SetDirection(transform.up.normalized);
            _shot.Invoke();
        }
    }

    private void Update()
    {
        if (ShotKeys.Any((key) => Input.GetKeyDown(key)) && _tempCooldown == 0)
        {
            Shoot();
            _tempCooldown = _cooldown;
        }

        if(_tempCooldown > 0 && !_isCooldownDecreases)
        {
            _isCooldownDecreases = true;
            Invoke(nameof(ResetCooldown), _cooldown);
        }
    }

    private void ResetCooldown()
    {
        _tempCooldown = 0;
        _isCooldownDecreases = false;
    }
}