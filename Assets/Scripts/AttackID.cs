using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackID", menuName = "AttackID", order = 0)]
public class AttackID : ScriptableObject 
{
    public GameObject attackHitbox;

    public bool isParented;

    [Header("Attack Info")]
    public float attackLength;

    //Should be multiplied by the direction
    [Tooltip("Knockback Magnitude")]
    public float knockbackForceHorizontal;
    public float knockbackForceVertical;
    public int damage;

    public float stunDuration;

    [Header("Movement")]
    public bool isDashImpulse;
    public float dashForce;
    public Vector3 dashDir;

    [Header("Effects on Attacker")]
    public float windupTime;
    public float cooldownTime;

    //[Header("Additional Effects")]



    public Vector3 CalculateKnockback(Transform transform)
    {
        return knockbackForceHorizontal * transform.forward + knockbackForceVertical * Vector3.up;
    }

}
