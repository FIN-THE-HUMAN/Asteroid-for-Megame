using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSysytem : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    public void SpawnEnemy()
    {
        Debug.Log("SpawnEnemy");
        Invoke(nameof(TakeNewPosition), 3);
        Invoke(nameof(Revive), 5);

    }

    public void TakeNewPosition()
    {
        _enemy.transform.position = new Vector3(Random.Range(1, 49), 0, Random.Range(1, 49));
    }

    public void Revive()
    {
        _enemy.Animator.enabled = true;
        _enemy.gameObject.SetActive(true);
    }
}
