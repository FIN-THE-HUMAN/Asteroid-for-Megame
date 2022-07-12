using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private int _maxAsteroidGeneration;
    [SerializeField] private Asteroid _asteroidPrefab;
    [SerializeField] private float _asteroidSpeedMin = 0.02f;
    [SerializeField] private float _asteroidSpeedMax = 0.04f;
    [Range(0, 1)]
    [SerializeField] private float _smallAsteriodScaleSize = 0.625f;
    [Range(0, 360)]
    [SerializeField] private float _asteroidsAngles = 45f;
    public UnityEvent<Asteroid> AsteroidSpawned;
    public UnityEvent<Asteroid> AsteroidDestroyed;
    public UnityEvent<Asteroid> AsteroidFullDestroyed;
    private float _screenBuffer;

    public float AsteroidSpeedMin => _asteroidSpeedMin;
    public float AsteroidSpeedMax => _asteroidSpeedMax;
    public int MaxAsteroidGeneration => _maxAsteroidGeneration;

    private void Start()
    {
        _screenBuffer = 4;
    }

    private Vector3 getScale(int generation)
    {
        return _asteroidPrefab.transform.localScale * Mathf.Pow( _smallAsteriodScaleSize, generation);
    }

    public Asteroid CreateAsteroid(int generation, Vector2 position, float speed, Vector2 direction)
    {
        //Asteroid asteroid = Instantiate(_asteroidPrefab, position, transform.rotation);
        Asteroid asteroid = _objectPool.GetAsteroid().GetComponent<Asteroid>();

        asteroid.transform.rotation = transform.rotation;
        asteroid.transform.position = position;
        asteroid.gameObject.SetActive(true);
        asteroid.SetGeneration(generation);
        asteroid.transform.localScale = getScale(generation);

        //asteroid.transform.localScale *= _smallAsteriodScaleSize;
        asteroid.SetSpeed(speed);
        asteroid.SetDirection(direction);

        asteroid?.AsteriodDestroyed.AddListener(() => AsteroidDestroyed.Invoke(asteroid));
        asteroid?.FullDestroyed.AddListener(() => AsteroidFullDestroyed.Invoke(asteroid));
        
        if (generation < _maxAsteroidGeneration)
        {
            float miniAsteroidsSpeed = Random.Range(_asteroidSpeedMin, _asteroidSpeedMax);
            asteroid?.AsteriodDestroyed.AddListener(() => CreateAsteroid(generation + 1, asteroid.transform.position, speed,  (Quaternion.AngleAxis(_asteroidsAngles, Vector3.forward) * direction).normalized));
            asteroid?.AsteriodDestroyed.AddListener(() => CreateAsteroid(generation + 1, asteroid.transform.position, speed,  (Quaternion.AngleAxis(-_asteroidsAngles, Vector3.forward) * direction).normalized));
        }

        AsteroidSpawned.Invoke(asteroid);

        return asteroid;
    }

    //public void ResetAsteroidSize(Asteroid asteroid)
    //{
    //    asteroid.transform.localScale = _asteroidPrefab.transform.localScale;
    //}
}
