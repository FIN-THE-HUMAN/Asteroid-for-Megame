using UnityEngine;

public class UFOMovement : MonoBehaviour
{
    private Vector3 _direction;

    public Vector3 Direction => _direction;

    private void Start()
    {
        float xDirection = Random.Range(0, 2) > 0 ? 1 : -1;

        _direction = new Vector3(xDirection, 0, 0);
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, Constants.UFO.UFO_SPEED);
        ScreenUtils.KeepWithinTheScreen(transform);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }
}
