using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public PlayerScript playerScript;
    //PlayerID playerInfo;
    CharacterID characterInfo;

    [SerializeField]
    bool onCooldown = false;

    [Header("Attacking")]
    AttackID[] attacks;
    public Transform[] attackPositions;

    void Start()
    {
        //playerInfo = playerScript.playerID;
        characterInfo = playerScript.characterID;
        attacks = playerScript.characterID.attackInfos;
    }

    void Update()
    {
        
    }

    public void Attack(int attackIndex)
    {
        if (!onCooldown)
        {
            StartCoroutine(waitForWindupTime(attacks[attackIndex].windupTime));
            //Need to make this attack position interchangeable
            SpawnHitbox(attacks[attackIndex], attackPositions[attackIndex]);
            StartCoroutine(waitForCooldownTime(attacks[attackIndex].cooldownTime));
        }
    }

    void SpawnHitbox(AttackID attackInfo, Transform spawnPos)
    {
        //This will be based off of movement input and rotation
        Instantiate(attackInfo.attackHitbox, spawnPos.position, spawnPos.rotation, spawnPos);
    }

    IEnumerator waitForWindupTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    IEnumerator waitForCooldownTime(float waitTime)
    {
        onCooldown = true;
        yield return new WaitForSeconds(waitTime);

        onCooldown = false;
    }
}
