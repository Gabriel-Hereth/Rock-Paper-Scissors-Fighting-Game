using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class PlayerMovement2 : MonoBehaviour
{
    public PlayerScript playerScript;
    PlayerID playerInfo;
    PlayerInput playerInput;
    //Rigidbody rb;
    CharacterController characterController;


    Vector3 moveDir;

    Vector3 v3Gravity;

    Vector3 knockback;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        //rb = GetComponent<Rigidbody>();
        playerInfo = playerScript.playerID;
        playerInput = playerScript.inputScript;

        v3Gravity = Vector3.zero;
    }

    private void Update()
    {
        moveDir = playerInput.movementInput.normalized;

        if(characterController.isGrounded == false)
        {
            v3Gravity = new Vector3(0f, -playerInfo.gravity, 0f);
        }
        else
        {
            v3Gravity = Vector3.zero;
        }
        
        characterController.Move((moveDir * playerInfo.acceleration + v3Gravity + knockback)* Time.deltaTime);
        knockback = Vector3.zero;
    }

    public void AddKnockback(Vector3 knockbackForce)
    {
        knockback = knockbackForce;
    }
}*/
