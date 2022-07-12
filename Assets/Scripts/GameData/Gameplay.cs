using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private RocketMovements _rocket;
    [SerializeField] private AsteroidSpawner _asteroidSpawner;
    [SerializeField] private ScoreManager _scoreManager;
    [SerializeField] private StatPresenter statPresenter;
    [SerializeField] private float _asteroidSpawnCooldown = 2f;
    [SerializeField] private int _asteroidsToSpawn;
    [SerializeField] private GameLoadScriptableObject _gameLoadScriptableObject;
    [SerializeField] private UnityEvent _rocketFail;

    private int _tempAsteroidsToSpawn;
    private int _asteroidsToNextWaveSpawn;

    public int TempAsteroidsToSpawn => _tempAsteroidsToSpawn;
    public int AsteroidsToNextWaveSpawn => _asteroidsToNextWaveSpawn;

    private void Start()
    {
        if (!_gameLoadScriptableObject.LoadGame)
        {
            _tempAsteroidsToSpawn = _asteroidsToSpawn;
            //_asteroidsToNextWaveSpawn = _asteroidsToSpawn * (int)(Mathf.Pow(2, _asteroidSpawner.MaxAsteroidGeneration + 1) - 1);
            for (int i = 0; i < _tempAsteroidsToSpawn; i++)
            {
                StandartAsteroidSpawn();
            }
        }

    }

    public void SetTempAsteroidsToSpawn(int tempAsteroidsToSpawn)
    {
        if (tempAsteroidsToSpawn < 0) throw new System.InvalidOperationException("tempAsteroidsToSpawn < 0");
        _tempAsteroidsToSpawn = tempAsteroidsToSpawn;
    }

    public void SetAsteroidsToNextWaveSpawn(int asteroidsToNextWaveSpawn)
    {
        if (asteroidsToNextWaveSpawn < 0) throw new System.InvalidOperationException("asteroidsToNextWaveSpawn < 0");
        _asteroidsToNextWaveSpawn = asteroidsToNextWaveSpawn;
    }

    private void StandartAsteroidSpawn()
    {
        Debug.Log("StandartAsteroidSpawn");
        Vector2 asteroidPosition = ScreenUtils.GetRandomBorderPointPosition(3);
        Asteroid asteroid = _asteroidSpawner.CreateAsteroid(
            0,
            asteroidPosition,
            Random.Range(_asteroidSpawner.AsteroidSpeedMin, _asteroidSpawner.AsteroidSpeedMax),
            new Vector2(Random.Range(0, -asteroidPosition.x), Random.Range(0, -asteroidPosition.y)).normalized
        );
    }

    public void IncreaseAsteroidsToNextWaveSpawn(Asteroid asteroid)
    {
        _asteroidsToNextWaveSpawn -= (int)(Mathf.Pow(2, _asteroidSpawner.MaxAsteroidGeneration - asteroid.Generation + 1) - 1);
    }

    public void TrySpawnNewAsteroids()
    {
        _asteroidsToNextWaveSpawn--;

        if (_asteroidsToNextWaveSpawn < 0) throw new System.InvalidOperationException("Live Ateroids count is less than 0");

        if (_asteroidsToNextWaveSpawn == 0)
        {
            Invoke(nameof(SpawnAteroidAfterSomeTime), _asteroidSpawnCooldown);
        } 
    }

    public void UpdateNewWaveCount(Asteroid asteroid)
    {
        if(asteroid.Generation == 0)
            _asteroidsToNextWaveSpawn += (int)(Mathf.Pow(2, _asteroidSpawner.MaxAsteroidGeneration + 1) - 1);
    }

    private void SpawnAteroidAfterSomeTime()
    {
        _tempAsteroidsToSpawn++;
        for (int i = 0; i < _tempAsteroidsToSpawn; i++)
        {
            StandartAsteroidSpawn();
        }
    }

    public void LoseGameCauseRocketFail()
    {
        Cursor.visible = true;
        Time.timeScale = 0;
        _rocketFail.Invoke();
    }
}
