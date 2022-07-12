using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RocketMovingControls
{
    Keyboard,
    MouseAndKeyboard
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CreateRocketControls", order = 1)]
public class RocketControlsScriptableObject : ScriptableObject
{
    public RocketMovingControls Controls;
}
