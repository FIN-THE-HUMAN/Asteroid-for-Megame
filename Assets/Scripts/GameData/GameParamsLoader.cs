using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameParamsLoader : MonoBehaviour
{
    [SerializeField] private GameLoadScriptableObject _gameLoadScriptableObject;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private UFOBullet _ufoBulletPrefab;
    [SerializeField] private Asteroid _asteroidPrefab;
    [SerializeField] private UFOMovement _ufoPrefab;
    [SerializeField] private RocketMovements _rocket;
    [SerializeField] private BulletShot _bulletShot;
    [SerializeField] private RocketInvulnerabilityView _rocketInvulnerabilityView;
    [SerializeField] private ScoreManager _ScoreManager;
    [SerializeField] private AsteroidSpawner _asteroidSpawner;
    [SerializeField] private UFOSpawner _ufoSpawner;
    [SerializeField] private Gameplay _gameplay;
    public void Start()
    {
        if (_gameLoadScriptableObject.LoadGame) LoadParams();
    }

    public void LoadParams()
    {
        Bullet[] bullets = new Bullet[PlayerPrefs.GetInt("bulletsCount")];
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i] = Instantiate<Bullet>(_bulletPrefab);
            bullets[i].transform.position = new Vector3(PlayerPrefs.GetFloat("bullet" + i + "x"), PlayerPrefs.GetFloat("bullet" + i + "y"), PlayerPrefs.GetFloat("bullet" + i + "z"));
            bullets[i].SetReachedDistance(PlayerPrefs.GetFloat("bullet" + i + "ReachedDistance"));
            bullets[i].SetPrevLoc(new Vector3(PlayerPrefs.GetFloat("bullet" + i + "PrevLocX"), PlayerPrefs.GetFloat("bullet" + i + "PrevLocY"), PlayerPrefs.GetFloat("bullet" + i + "PrevLocZ")));
            bullets[i].SetDirection(new Vector3(PlayerPrefs.GetFloat("bullet" + i + "DirectionX"), PlayerPrefs.GetFloat("bullet" + i + "DirectionY"), PlayerPrefs.GetFloat("bullet" + i + "DirectionZ")));
        }

        UFOBullet[] ufoBullets = new UFOBullet[PlayerPrefs.GetInt("ufoBulletsCount")];
        for (int i = 0; i < ufoBullets.Length; i++)
        {
            ufoBullets[i] = Instantiate<UFOBullet>(_ufoBulletPrefab);
            ufoBullets[i].transform.position = new Vector3(PlayerPrefs.GetFloat("ufoBullet" + i + "x"), PlayerPrefs.GetFloat("ufoBullet" + i + "y"), PlayerPrefs.GetFloat("ufoBullet" + i + "z"));
            ufoBullets[i].SetReachedDistance(PlayerPrefs.GetFloat("ufoBullet" + i + "ReachedDistance"));
            ufoBullets[i].SetPrevLoc(new Vector3(PlayerPrefs.GetFloat("ufoBullet" + i + "PrevLocX"), PlayerPrefs.GetFloat("ufoBullet" + i + "PrevLocY"), PlayerPrefs.GetFloat("ufoBullet" + i + "PrevLocZ")));
            ufoBullets[i].SetDirection(new Vector3(PlayerPrefs.GetFloat("ufoBullet" + i + "DirectionX"), PlayerPrefs.GetFloat("ufoBullet" + i + "DirectionY"), PlayerPrefs.GetFloat("ufoBullet" + i + "DirectionZ")));
        }

        Asteroid[] asteroids = new Asteroid[PlayerPrefs.GetInt("asteroidsCount")];
        for (int i = 0; i < asteroids.Length; i++)
        {
            asteroids[i] = _asteroidSpawner.CreateAsteroid(
                PlayerPrefs.GetInt("asteroid" + i + "Generation"), 
                new Vector2(PlayerPrefs.GetFloat("asteroid" + i + "x"), PlayerPrefs.GetFloat("asteroid" + i + "y")),
                PlayerPrefs.GetFloat("asteroid" + i + "Speed"),
                new Vector2(PlayerPrefs.GetFloat("asteroid" + i + "DirectionX"), PlayerPrefs.GetFloat("asteroid" + i + "DirectionY")));
            asteroids[i].SetRotation(PlayerPrefs.GetFloat("asteroid" + i + "Rotation"));
        }

        UFOMovement[] ufos = new UFOMovement[PlayerPrefs.GetInt("ufosCount")];
        for (int i = 0; i < ufos.Length; i++)
        {
            ufos[i] = _ufoSpawner.CreateUFO(PlayerPrefs.GetFloat("ufo" + i + "x"), PlayerPrefs.GetFloat("ufo" + i + "y"));
            //ufos[i].transform.position = new Vector3(, PlayerPrefs.GetFloat("ufo" + i + "z"));
            ufos[i].SetDirection(new Vector3(PlayerPrefs.GetFloat("ufo" + i + "DirectionX"), PlayerPrefs.GetFloat("ufo" + i + "DirectionY"), PlayerPrefs.GetFloat("ufo" + i + "DirectionZ")));
        }

        var rocket = FindObjectOfType<RocketMovements>();
        rocket.FollowMouse = PlayerPrefs.GetInt("rocket" + "FollowMouse") > 0 ? true : false;
        rocket.transform.position = new Vector3(PlayerPrefs.GetFloat("rocket" + "x"), PlayerPrefs.GetFloat("rocket" + "y"), PlayerPrefs.GetFloat("rocket" + "z"));
        rocket.SetDirection(new Vector3(PlayerPrefs.GetFloat("rocket" + "DirectionX"), PlayerPrefs.GetFloat("rocket" + "DirectionY"), PlayerPrefs.GetFloat("rocket" + "DirectionZ")));
        rocket.SetRotationSpeed(PlayerPrefs.GetFloat("rocket" + "RotationSpeed"));

        var bulletShot = FindObjectOfType<BulletShot>();
        bulletShot.SetTempCooldown(PlayerPrefs.GetFloat("bulletShot" + "TempCooldown"));
        bulletShot.SetIsCooldownDecreases(PlayerPrefs.GetInt("bulletShot" + "IsCooldownDecreases") > 1 ? true : false);

        var rocketInvulnerabilityView = FindObjectOfType<RocketInvulnerabilityView>();
        rocketInvulnerabilityView.SetTempCooldown(PlayerPrefs.GetInt("rocketInvulnerabilityView" + "TempCooldown"));
        rocketInvulnerabilityView.enabled = PlayerPrefs.GetInt("rocketInvulnerabilityView" + "enabled") > 0 ? true : false;
        
        var scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.SetScore(PlayerPrefs.GetInt("scoreManager" + "Score"));

        var rocketLive = FindObjectOfType<RocketLive>();
        rocketLive.SetLives(PlayerPrefs.GetInt("rocket" + "lives"));

        var gameplay = FindObjectOfType<Gameplay>();
        gameplay.SetTempAsteroidsToSpawn(PlayerPrefs.GetInt("gameplay" + "TempAsteroidsToSpawn"));
        gameplay.SetAsteroidsToNextWaveSpawn(PlayerPrefs.GetInt("gameplay" + "AsteroidsToNextWaveSpawn"));

    }

    public void ClearSave()
    {
        _gameLoadScriptableObject.GameWasSaved = false;
        _gameLoadScriptableObject.LoadGame = false;
    }
}
