using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuButtonViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text controlSettingButtonText;

    public void SetControlSettingButtonText(RocketMovingControls controls)
    {
        controlSettingButtonText.text = controls == RocketMovingControls.Keyboard ? "Controls: Keyboard" : "Controls: Keyboard And Mouse";
    }
}
