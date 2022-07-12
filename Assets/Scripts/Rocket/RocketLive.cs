using UnityEngine;
using UnityEngine.Events;

public class RocketLive : MonoBehaviour
{
    [SerializeField] private int _lives = 3;
    [SerializeField] private float _startInvulnerabilityTime = 3;
    [SerializeField] private RocketInvulnerabilityView _invulnerabilityView;
    [SerializeField] private UnityEvent Destroyed;
    [SerializeField] private UnityEvent<int> Damaged;
    [SerializeField] private UnityEvent<int> LivesUpdated;
    private bool _isInvulnerable = true;
    private void Start()
    {
        LivesUpdated.Invoke(_lives);
        Invoke(nameof(RemoveInvulnerability), _startInvulnerabilityTime);
    }

    public int GetLives()
    {
        return _lives;
    }

    public void SetLives(int lives)
    {
        _lives = lives;
    }

    public void RemoveInvulnerability()
    {
        _isInvulnerable = false;
        _invulnerabilityView.enabled = false;
    }
    public void SetInvulnerabilityForSomeTime(float time)
    {
        _isInvulnerable = true;
        _invulnerabilityView.enabled = true;
        Invoke(nameof(RemoveInvulnerability), time);
    }

    public void GetDamage()
    {
        _lives--;
        transform.position = new Vector3(0, 0, 0);
        SetInvulnerabilityForSomeTime(_startInvulnerabilityTime);
        if (_lives <= 0) Destroy();
        Damaged.Invoke(_lives);
        LivesUpdated.Invoke(_lives);
    }

    public void Destroy()
    {
        Destroyed.Invoke();
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Asteroid>() && !_isInvulnerable)
        {
            GetDamage();
        }
    }
}
