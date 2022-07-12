using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameLoadScriptableObject", menuName = "ScriptableObjects/GameLoad", order = 1)]
public class GameLoadScriptableObject : ScriptableObject
{
    public bool GameWasSaved;
    public bool LoadGame;
}
