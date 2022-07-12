using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookMouseTrace : MonoBehaviour
{
    [SerializeField] private Transform _playerPart;
    public Vector3 rot;

    void Start()
    {
        
    }

    private void LateUpdate()
    {
        //_playerPart.localEulerAngles = rot;
        //_playerPart.LookAt(new Vector3(hit.point.x, _playerPart.position.y, hit.point.z));

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, 100))
        {
            _playerPart.LookAt(new Vector3(raycastHit.point.x, _playerPart.position.y, raycastHit.point.z));
            _playerPart.Rotate(0, -90, 0);
            _playerPart.Rotate(0, 0, -90);
            //_playerPart.forward = (new Vector3(raycastHit.point.x, _playerPart.position.y, raycastHit.point.z) - transform.position).normalized;
        }
        else
        {
            var lookInAbyssVector = ray.direction * 100;
            _playerPart.LookAt(new Vector3(lookInAbyssVector.x, _playerPart.position.y, lookInAbyssVector.z));
            _playerPart.Rotate(0, -90, 0);
            _playerPart.Rotate(0, 0, -90);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit raycastHit;
        //Vector3 v;
        //if (Physics.Raycast(ray, out raycastHit, 100))
        //{
        //    _playerPart.LookAt(new Vector3(raycastHit.point.x, _playerPart.position.y, raycastHit.point.z));
        //}
        //else
        //{
        //    (ray.direction - Camera.main.transform.position).
        //}


        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            //_playerPart.LookAt(new Vector3(hit.point.x, _playerPart.position.y, hit.point.z));
            _playerPart.localEulerAngles = rot;
            //_playerPart.localEulerAngles = Quaternion.LookRotation(transform.forward, transform.position - new Vector3(hit.point.x, _playerPart.position.y, hit.point.z)).ToEulerAngles();
            //_playerPart.localEulerAngles = Quaternion.eul
        }
        else
        {
            var longRayDirection = ray.direction * 100;
            _playerPart.LookAt(new Vector3(longRayDirection.x, _playerPart.position.y, longRayDirection.z));
        }

    }
}
