using UnityEngine;
using UnityEngine.Events;

public class UFOLive : MonoBehaviour
{
    public UnityEvent Destroyed;

    public void Destroy()
    {
        Destroyed.Invoke();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            Destroy();
        }

        Asteroid asteroid;
        if (asteroid = collision.gameObject.GetComponent<Asteroid>())
        {
            asteroid.FullDestroy();
            Destroy();
        }

        RocketLive rocket;
        if (rocket = collision.gameObject.GetComponent<RocketLive>())
        {
            rocket.GetDamage();
        }
    }
}
