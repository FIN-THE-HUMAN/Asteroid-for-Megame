using UnityEngine;
using UnityEngine.Events;

public class Asteroid : MonoBehaviour
{
    private float maxRotation;
    private float rotaionX;
    private int _generation;
    private float _speed;
    private Vector2 _direction;

    public int Generation => _generation;
    public float Speed => _speed;
    public Vector2 Direction => _direction;
    public float Rotation => rotaionX;

    public UnityEvent AsteriodDestroyed;
    public UnityEvent FullDestroyed;

    private void Start()
    {
        maxRotation = 25;
        rotaionX = Random.Range(-maxRotation, maxRotation);
    }

    public void SetRotation(float rotation)
    {
        rotaionX = rotation;
    }

    public void SetDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void SetGeneration(int generation)
    {
        if (generation < 0) throw new System.InvalidOperationException("generation < 0");
        _generation = generation;
    }

    public Vector2 GetDirection()
    {
        return _direction;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(_direction.x, _direction.y, 0) * _speed;
        transform.Rotate(new Vector3(0, 0, rotaionX) * Time.deltaTime);
        ScreenUtils.KeepWithinTheScreen(transform);
    }

    public void DestroyAsteroid()
    {
        AsteriodDestroyed.Invoke();
        //Destroy(gameObject);
        gameObject.SetActive(false);
        AsteriodDestroyed.RemoveAllListeners();
    }

    public void FullDestroy()
    {
        FullDestroyed.Invoke();
        //Destroy(gameObject);
        gameObject.SetActive(false);
        AsteriodDestroyed.RemoveAllListeners();
    }
}
