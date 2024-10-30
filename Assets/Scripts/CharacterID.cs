using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterInfo")]
public class CharacterID : ScriptableObject
{
    public enum attackIndexes{
        regularAttack,
        evasionAttack,
        specialAttack
    }

    //public GameObject characterModel;

    [Header("Movement")]
    public float maxSpeed;
    public float acceleration;
    public float jumpForce;

    [Header("Abilities")]
    public AttackID[] attackInfos;
}
