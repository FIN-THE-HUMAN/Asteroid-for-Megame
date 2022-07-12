using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_player.CanMove) return;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _player.transform.forward * Input.GetAxis("Vertical"), _player.Speed);
    }
}
