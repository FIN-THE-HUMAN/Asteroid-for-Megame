using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class RocketMovements : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 180f;
    [SerializeField] private float _acceleration = 0.1f;
    [SerializeField] private float _maxSpeed = 0.01f;
    public bool FollowMouse;
    private Vector3 _direction;
    private float _speed;
    public Vector3 Direction => _direction;
    public float RotationSpeed => _rotationSpeed;
    //private Vector3 _oldPosition;
    //private Vector3 _newPosition;

    [SerializeField] private UnityEvent<Transform, float> RocketMoved;
    [SerializeField] private UnityEvent RocketAccelerate;
    private void Start()
    {
        _direction = transform.position;
        //_oldPosition = transform.position;
        //_newPosition = transform.position;
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    public void SetRotationSpeed(float rotationSpeed)
    {
        _rotationSpeed = rotationSpeed;
    }

    private void FixedUpdate()
    {
        ControlRocket();
        ScreenUtils.KeepWithinTheScreen(transform);
    }

    public float GetSpeed()
    {
        return _speed;
    }

    private void Rotation()
    {
        if (FollowMouse)
        {
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();
            float rot = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, rot - 90), _rotationSpeed / 50);
        }
        else
            transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * _rotationSpeed);
    }

    private void ControlRocket()
    {
        Rotation();

        if (Input.GetAxis("Vertical") > 0 || (FollowMouse && Input.GetKey(KeyCode.Mouse1)))
        {
            if ((_direction + transform.up * _acceleration).magnitude < _direction.magnitude || GetSpeed() <= _maxSpeed)
            {
                _direction += transform.up * _acceleration;
                _speed = Vector3.Distance(transform.position, transform.position + _direction);
                RocketAccelerate.Invoke();
            }
        }
        
        transform.position = Vector3.Lerp(transform.position, transform.position + _direction, Time.fixedDeltaTime);
        if (transform.hasChanged)
        {
            RocketMoved.Invoke(transform, _speed);
        }
    }
}
