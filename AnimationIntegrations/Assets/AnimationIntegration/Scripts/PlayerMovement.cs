using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _movingSpeed;
    [SerializeField] private GameObject _rotatable;
    [SerializeField] private GameObject _rotationPivot;
    [SerializeField] private GameObject _movable;
    [SerializeField] private Animator _animator;
    public bool CanMove = true;
    public float Speed => _movingSpeed;

    void Start()
    {
        
    }

    private void Update()
    {
        _animator.SetBool("isRunning", Input.GetAxis("Vertical") != 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!CanMove) return;
        _movable.transform.position = Vector3.MoveTowards(_movable.transform.position, _movable.transform.position + _rotatable.transform.forward * Input.GetAxis("Vertical"), _movingSpeed);
        //transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal"), _movingSpeed);

        //_rotatable.transform.Rotate(0, Input.GetAxis("Horizontal") * _rotationSpeed, 0);

        _rotatable.transform.RotateAround(_rotationPivot.transform.position, Vector3.up, Input.GetAxis("Horizontal") * _rotationSpeed);
    }
}
