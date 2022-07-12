using UnityEngine;
using UnityEngine.Events;

public class UFOShot : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private UFOBullet _bulletPrefab;
    [SerializeField] private float _cooldownMin;
    [SerializeField] private float _cooldownMax;
    [SerializeField] private RocketMovements _target;
    [SerializeField] private UnityEvent _shot;

    private float _tempCooldown;

    private void Start()
    {

    }

    public void SetTarget(RocketMovements target)
    {
        _target = target;
    }

    public void SetObjectPool(ObjectPool objectPool)
    {
        _objectPool = objectPool;
    }

    private void Shoot()
    {
        //UFOBullet bullet = Instantiate(_bulletPrefab, new Vector2(transform.position.x, transform.position.y), transform.rotation);
        //bullet.SetDirection((_target.transform.position - transform.position).normalized);
        //_shot.Invoke();
        Debug.Log("ObjectPool.GetPooledUFOBullet() == null" + _objectPool.GetPooledUFOBullet() == null);
        UFOBullet bullet = _objectPool.GetPooledUFOBullet().GetComponent<UFOBullet>();

        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.gameObject.SetActive(true);

            bullet.SetDirection((_target.transform.position - transform.position).normalized);
            _shot.Invoke();
        }
    }

    private void FixedUpdate()
    {
        if (_tempCooldown > 0)
        {
            _tempCooldown -= Time.fixedDeltaTime;
            if (_tempCooldown < 0) _tempCooldown = 0;
        }

        if (_tempCooldown <= 0)
        {
            Shoot();
            _tempCooldown = Random.Range(_cooldownMin, _cooldownMax);
        }
    }
}
