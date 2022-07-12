using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    [SerializeField] private GameLoadScriptableObject _gameLoadScriptableObject;
    public void Save()
    {
        var bullets = FindObjectsOfType<Bullet>();
        PlayerPrefs.SetInt("bulletsCount", bullets.Length);
        for (int i = 0; i < bullets.Length; i++)
        {
            PlayerPrefs.SetFloat("bullet" + i + "x", bullets[i].transform.position.x);
            PlayerPrefs.SetFloat("bullet" + i + "y", bullets[i].transform.position.y);
            PlayerPrefs.SetFloat("bullet" + i + "z", bullets[i].transform.position.z);
            PlayerPrefs.SetFloat("bullet" + i + "ReachedDistance", bullets[i].ReachedDistance);
            PlayerPrefs.SetFloat("bullet" + i + "PrevLocX", bullets[i].PrevLoc.x);
            PlayerPrefs.SetFloat("bullet" + i + "PrevLocY", bullets[i].PrevLoc.y);
            PlayerPrefs.SetFloat("bullet" + i + "PrevLocZ", bullets[i].PrevLoc.z);

            PlayerPrefs.SetFloat("bullet" + i + "DirectionX", bullets[i].Direction.x);
            PlayerPrefs.SetFloat("bullet" + i + "DirectionY", bullets[i].Direction.y);
            PlayerPrefs.SetFloat("bullet" + i + "DirectionZ", bullets[i].Direction.z);
        }

        var ufoBullets = FindObjectsOfType<UFOBullet>();
        PlayerPrefs.SetInt("ufoBulletsCount", ufoBullets.Length);
        for (int i = 0; i < ufoBullets.Length; i++)
        {
            PlayerPrefs.SetFloat("ufoBullet" + i + "x", ufoBullets[i].transform.position.x);
            PlayerPrefs.SetFloat("ufoBullet" + i + "y", ufoBullets[i].transform.position.y);
            PlayerPrefs.SetFloat("ufoBullet" + i + "z", ufoBullets[i].transform.position.z);
            PlayerPrefs.SetFloat("ufoBullet" + i + "ReachedDistance", ufoBullets[i].ReachedDistance);
            PlayerPrefs.SetFloat("ufoBullet" + i + "PrevLocX", ufoBullets[i].PrevLoc.x);
            PlayerPrefs.SetFloat("ufoBullet" + i + "PrevLocY", ufoBullets[i].PrevLoc.y);
            PlayerPrefs.SetFloat("ufoBullet" + i + "PrevLocZ", ufoBullets[i].PrevLoc.z);

            PlayerPrefs.SetFloat("ufoBullet" + i + "DirectionX", ufoBullets[i].Direction.x);
            PlayerPrefs.SetFloat("ufoBullet" + i + "DirectionY", ufoBullets[i].Direction.y);
            PlayerPrefs.SetFloat("ufoBullet" + i + "DirectionZ", ufoBullets[i].Direction.z);
        }

        var asteroids = FindObjectsOfType<Asteroid>();
        PlayerPrefs.SetInt("asteroidsCount", asteroids.Length);
        for (int i = 0; i < asteroids.Length; i++)
        {
            PlayerPrefs.SetFloat("asteroid" + i + "x", asteroids[i].transform.position.x);
            PlayerPrefs.SetFloat("asteroid" + i + "y", asteroids[i].transform.position.y);
            PlayerPrefs.SetFloat("asteroid" + i + "z", asteroids[i].transform.position.z);
            PlayerPrefs.SetInt("asteroid" + i + "Generation", asteroids[i].Generation);
            PlayerPrefs.SetFloat("asteroid" + i + "Speed", asteroids[i].Speed);
            PlayerPrefs.SetFloat("asteroid" + i + "DirectionX", asteroids[i].Direction.x);
            PlayerPrefs.SetFloat("asteroid" + i + "DirectionY", asteroids[i].Direction.y);
            PlayerPrefs.SetFloat("asteroid" + i + "Rotation", asteroids[i].Rotation);
        }

        var ufos = FindObjectsOfType<UFOMovement>();
        PlayerPrefs.SetInt("ufosCount", ufos.Length);
        for (int i = 0; i < ufos.Length; i++)
        {
            PlayerPrefs.SetFloat("ufo" + i + "x", ufos[i].transform.position.x);
            PlayerPrefs.SetFloat("ufo" + i + "y", ufos[i].transform.position.y);
            PlayerPrefs.SetFloat("ufo" + i + "z", ufos[i].transform.position.z);
            PlayerPrefs.SetFloat("ufo" + i + "DirectionX", ufos[i].Direction.x);
            PlayerPrefs.SetFloat("ufo" + i + "DirectionY", ufos[i].Direction.y);
            PlayerPrefs.SetFloat("ufo" + i + "DirectionZ", ufos[i].Direction.z);
        }

        var rocket = FindObjectOfType<RocketMovements>();
        PlayerPrefs.SetInt("rocket" + "FollowMouse", rocket.FollowMouse ? 1 : 0);
        PlayerPrefs.SetFloat("rocket" + "x", rocket.transform.position.x);
        PlayerPrefs.SetFloat("rocket" + "y", rocket.transform.position.y);
        PlayerPrefs.SetFloat("rocket" + "z", rocket.transform.position.z);
        PlayerPrefs.SetFloat("rocket" + "DirectionX", rocket.Direction.x);
        PlayerPrefs.SetFloat("rocket" + "DirectionY", rocket.Direction.y);
        PlayerPrefs.SetFloat("rocket" + "DirectionZ", rocket.Direction.z);
        PlayerPrefs.SetFloat("rocket" + "RotationSpeed", rocket.RotationSpeed);

        var bulletShot = FindObjectOfType<BulletShot>();
        PlayerPrefs.SetFloat("bulletShot" + "TempCooldown", bulletShot.TempCooldown);
        PlayerPrefs.SetInt("bulletShot" + "IsCooldownDecreases", bulletShot.IsCooldownDecreases ? 1 : 0);

        var rocketInvulnerabilityView = FindObjectOfType<RocketInvulnerabilityView>();
        PlayerPrefs.SetInt("rocketInvulnerabilityView" + "TempCooldown", rocketInvulnerabilityView.TempCooldown);
        PlayerPrefs.SetInt("rocketInvulnerabilityView" + "enabled", rocketInvulnerabilityView.enabled ? 1 : 0);

        var scoreManager = FindObjectOfType<ScoreManager>();
        PlayerPrefs.SetInt("scoreManager" + "Score", scoreManager.Score);

        var rocketLive = FindObjectOfType<RocketLive>();
        PlayerPrefs.SetInt("rocket" + "lives", rocketLive.GetLives());

        var gameplay = FindObjectOfType<Gameplay>();
        PlayerPrefs.SetInt("gameplay" + "TempAsteroidsToSpawn", gameplay.TempAsteroidsToSpawn);
        PlayerPrefs.SetInt("gameplay" + "AsteroidsToNextWaveSpawn", gameplay.AsteroidsToNextWaveSpawn);

        _gameLoadScriptableObject.GameWasSaved = true;
        PlayerPrefs.Save();
    }
}
