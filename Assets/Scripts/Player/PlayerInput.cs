using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerScript playerScript;
    PlayerMovement3 playerMovementScript;
    PlayerID playerInfo;
    //CharacterID characterInfo;

    int forwardInput;
    int backwardInput;
    int rightwardInput;
    int leftwardInput;

    int horizontalInput;
    int verticalInput;
    public Vector3 movementInput;

    void Start()
    {
        playerInfo = playerScript.playerID;
        playerMovementScript = playerScript.movementScript;
        //characterInfo = playerScript.characterID;
    }


    void Update()
    {
        MovementInput();
        AttackInput();
        JumpInput();
    }

    void MovementInput()
    {
        //Give the most recently pressed key priority so that when you press a new key it will switch to that input

        if (Input.GetKey(playerInfo.forwardKey))
        {
            forwardInput = 1;
        }
        else { forwardInput = 0; }
        if (Input.GetKey(playerInfo.backwardKey))
        {
            backwardInput = -1;
        }
        else { backwardInput = 0; }

        if (Input.GetKey(playerInfo.rightwardKey))
        {
            rightwardInput = 1;
        }
        else { rightwardInput = 0; }
        if (Input.GetKey(playerInfo.lefwardKey))
        {
            leftwardInput = -1;
        }
        else { leftwardInput = 0; }

        verticalInput = forwardInput + backwardInput;
        horizontalInput = rightwardInput + leftwardInput;

        movementInput = new Vector3(horizontalInput, 0f, verticalInput);
    }

    void JumpInput()
    {
        if (Input.GetKeyDown(playerInfo.jumpKey))
        {
            playerMovementScript.Jump();
        }
    }

    void AttackInput()
    {
        if (Input.GetKeyDown(playerInfo.attackKey))
        {
            playerScript.abilityScript.Attack((int)CharacterID.attackIndexes.regularAttack);
        }
        if (Input.GetKeyDown(playerInfo.evasionKey))
        {
            playerScript.abilityScript.Attack((int)CharacterID.attackIndexes.evasionAttack);
        }
        if (Input.GetKeyDown(playerInfo.specialKey))
        {
            playerScript.abilityScript.Attack((int)CharacterID.attackIndexes.specialAttack);
        }
    }
}