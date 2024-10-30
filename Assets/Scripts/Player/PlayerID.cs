using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo")]
public class PlayerID : ScriptableObject
{
    [Header("Keybinds")]
    public KeyCode forwardKey;
    public KeyCode backwardKey;
    public KeyCode lefwardKey;
    public KeyCode rightwardKey;
    public KeyCode jumpKey;

    [Header("Abilities")]
    public KeyCode attackKey;
    public KeyCode evasionKey;
    public KeyCode specialKey;

}
