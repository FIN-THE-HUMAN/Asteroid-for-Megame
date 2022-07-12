using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 _direction;
    private float _reachedDistance;
    private Vector3 _prevLoc;

    public Vector3 PrevLoc => _prevLoc;
    public float ReachedDistance => _reachedDistance;
    public Vector3 Direction => _direction;
    void Start()
    {
        _prevLoc = transform.position;
    }

    private void Update()
    {
        if (_reachedDistance > ScreenUtils.SceneWidth)
        {
            _reachedDistance = 0;
            gameObject.SetActive(false);
        }//Destroy(gameObject);
    }

    public void SetReachedDistance(float reachedDistance)
    {
        if(reachedDistance < 0) throw new System.InvalidOperationException("reachedDistance less than 0");
        _reachedDistance = reachedDistance;
    }

    public void SetPrevLoc(Vector3 prevLoc)
    {
        _prevLoc = prevLoc;
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!ScreenUtils.IsWithinScreen(transform, 2)) return;
        Asteroid asteroid;
        if (asteroid = collision.gameObject.GetComponent<Asteroid>())
        {
            asteroid.DestroyAsteroid();
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Vector3 direction = _direction.normalized * Constants.UFO.BULLET_SPEED;
        transform.position = Vector3.Lerp(transform.position, transform.position + direction, Time.fixedDeltaTime);
        _reachedDistance += direction.magnitude * Time.fixedDeltaTime;
        _prevLoc = transform.position;
        ScreenUtils.KeepWithinTheScreen(transform);
    }
}
