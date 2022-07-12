using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _lazerCooldownText;
    [SerializeField] private TMP_Text _rocketPositionText;
    [SerializeField] private TMP_Text _rocketRotationText;
    [SerializeField] private TMP_Text _rocketSpeedText;
    [SerializeField] private TMP_Text _lazerChargesText;

    public void SetPosition(Transform transform, float speed)
    {
        _rocketPositionText.text = transform.position.x.ToString("F1") + ":" + transform.position.y.ToString("F1");
    }

    public void SetRotation(Transform transform, float speed)
    {
        Vector3 verticalAxis = new Vector3(0, 1, 0);
        if (Vector3.Dot(verticalAxis, -transform.right) >= 0)
        {
            _rocketRotationText.text = Vector3.Angle(verticalAxis, transform.up).ToString("F1");
        }
        else
        {
            _rocketRotationText.text = (360 - Vector3.Angle(verticalAxis, transform.up)).ToString("F1");
        }
    }

    public void SetRocketSpeed(Transform transform, float speed)
    {
        _rocketSpeedText.text = speed.ToString("F3");
    }

    public void SetLazerCharges(int charges)
    {
        _lazerChargesText.text = charges.ToString();
    }

    public void SetLazerCooldown(float cooldown)
    {
        _lazerCooldownText.text = cooldown.ToString("F1");
    }

}
