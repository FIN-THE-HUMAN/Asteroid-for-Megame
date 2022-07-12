using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControlsSetter : MonoBehaviour
{
    [SerializeField] RocketControlsScriptableObject _rocketControlsScriptableObject;
    [SerializeField] BulletShot _bulletShot;
    [SerializeField] RocketMovements _rocketMovements;

    private void Start()
    {
        SetControls();
    }

    public void SetControls()
    {
        switch (_rocketControlsScriptableObject.Controls) 
        {
            case RocketMovingControls.Keyboard:
                _rocketMovements.FollowMouse = false;
                _bulletShot.ShotKeys = new List<KeyCode> { KeyCode.Space };
                break;
            case RocketMovingControls.MouseAndKeyboard:
                _rocketMovements.FollowMouse = true;
                _bulletShot.ShotKeys = new List<KeyCode> { KeyCode.Mouse0, KeyCode.Space };
                break;
            default:
                _rocketMovements.FollowMouse = false;
                _bulletShot.ShotKeys = new List<KeyCode> { KeyCode.Space };
                break;
        }
    }
}
