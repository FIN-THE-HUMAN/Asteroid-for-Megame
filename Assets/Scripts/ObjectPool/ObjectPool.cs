using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _asteroidPrefab;
    [SerializeField] private GameObject _ufoBulletPrefab;
    [SerializeField] private int _bulletsPullSize;
    [SerializeField] private int _ufoBulletsPullSize;
    [SerializeField] private int _asteroidsPullSize;
    private List<GameObject> _bullets = new List<GameObject>();
    private List<GameObject> _asteroids = new List<GameObject>();
    private List<GameObject> _ufoBullets = new List<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < _bulletsPullSize; i++)
        {
            var bullet = Instantiate(_bulletPrefab);
            bullet.gameObject.SetActive(false);
            _bullets.Add(bullet);
        }

        for (int i = 0; i < _ufoBulletsPullSize; i++)
        {
            var bullet = Instantiate(_ufoBulletPrefab);
            bullet.gameObject.SetActive(false);
            _ufoBullets.Add(bullet);
        }

        for (int i = 0; i < _asteroidsPullSize; i++)
        {
            var asteroid = Instantiate(_asteroidPrefab);
            asteroid.gameObject.SetActive(false);
            _asteroids.Add(asteroid);
        }
    }

    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < _bullets.Count; i++)
        {
            if (!_bullets[i].activeInHierarchy)
            {
                return _bullets[i];
            }
        }

        var newBullet = Instantiate(_bulletPrefab);
        newBullet.SetActive(true);
        _bullets.Add(newBullet);
        return newBullet;
    }
    public GameObject GetAsteroid()
    {
        for (int i = 0; i < _asteroids.Count; i++)
        {           
            if (!_asteroids[i].activeInHierarchy)
            {
                return _asteroids[i];
            }
        }

        var newAsteroid = Instantiate(_asteroidPrefab);
        newAsteroid.SetActive(true);
        _asteroids.Add(newAsteroid);
        return newAsteroid;
    }

    public GameObject GetPooledUFOBullet()
    {
        for (int i = 0; i < _ufoBullets.Count; i++)
        {
            if (!_ufoBullets[i].activeInHierarchy)
            {
                return _ufoBullets[i];
            }
        }

        var newBullet = Instantiate(_ufoBulletPrefab);
        newBullet.SetActive(true);
        _ufoBullets.Add(newBullet);
        return newBullet;
    }
}
