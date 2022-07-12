using UnityEngine;
using UnityEngine.Events;

public class UFOSpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private UFOShot _ufoPrefab;
    [SerializeField] private int _spawnCooldown;
    [SerializeField] private RocketMovements _shotTarget;
    public UnityEvent UFOSpawned;
    public UnityEvent UFODestroyed;
    private bool _noUFOonScreen = true;
    private int _tempSpawnCooldown;
    public UFOMovement CreateUFO(float x, float y)
    {
        var ufo = Instantiate(_ufoPrefab, new Vector2(x, y), Quaternion.identity);
        ufo.SetObjectPool(_objectPool);
        ufo.SetTarget(_shotTarget);
        ufo.gameObject?.GetComponent<UFOLive>()?.Destroyed.AddListener(() => UFODestroyed.Invoke());
        ufo.gameObject?.GetComponent<UFOLive>()?.Destroyed.AddListener(() => _noUFOonScreen = true);
        _noUFOonScreen = false;
        UFOSpawned.Invoke();
        return ufo.GetComponent<UFOMovement>();
    }

    private void Start()
    {
        _tempSpawnCooldown = _spawnCooldown;
    }

    private void FixedUpdate()
    {
        if (_tempSpawnCooldown > 0 && _noUFOonScreen)
        {
            _tempSpawnCooldown--;
            if (_tempSpawnCooldown < 0) _tempSpawnCooldown = 0;
        }

        if (_tempSpawnCooldown <= 0 && _noUFOonScreen)
        {
            Vector2 coords = ScreenUtils.GetRandomHorizontalBorderPointPosition(0.2f);
            CreateUFO(coords.x, coords.y);
            _tempSpawnCooldown = _spawnCooldown;
        }
    }
}
