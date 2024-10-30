using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement3 : MonoBehaviour
{
    public PlayerScript playerScript;
    PlayerID playerInfo;
    CharacterID characterInfo;
    PlayerInput playerInput;
    Rigidbody rb;

    public float skinWidth = 0.2f;

    public bool canMove = true;
    Vector3 moveDir;
    bool hasReachedMaxSpeed;
    public float jumpCooldownTimer;

    Vector3 uncheckedVelocity;
    Vector3 knockback;

    public float groundDrag;

    [Header("Ground Check")]
    float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    //[Header("Air Control (eventually)")]


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInfo = playerScript.playerID;
        characterInfo = playerScript.characterID;
        playerInput = playerScript.inputScript;

        playerHeight = GetComponent<Collider>().bounds.size.y;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + skinWidth, whatIsGround);

        rb.drag = grounded ? groundDrag : 0;
        jumpCooldownTimer += Time.deltaTime;
    }

    private void FixedUpdate() 
    {
        if(canMove){
            MovePlayer();
        }
        CheckSpeed();
    }

    private void MovePlayer()
    {

        //This could be used to calculate the direction the player moves based off of orentation
        //moveDir = orientation.forward * playerInput.movementInput.z + orientation.right * playerInput.movementInput.x;

        moveDir = playerInput.movementInput;

        rb.AddForce(moveDir.normalized * characterInfo.acceleration, ForceMode.Force);
        MovePlayerUnchecked();

        //Figure out a better way to reset knockback
        knockback = Vector3.zero;
    }


    public void Jump()
    {
        if (grounded && jumpCooldownTimer > 0.1f)
        {
            rb.AddForce(characterInfo.jumpForce * Vector3.up, ForceMode.Impulse);
            jumpCooldownTimer = 0;
        }
    }

    //Put any forces in here that you don't want to get limited by CheckSpeed()
    private void MovePlayerUnchecked()
    {
        Vector3 velBeforeForceApplied = new Vector3(rb.velocity.z, 0f, rb.velocity.z);

        //Add force in here
        //------------------------------------------
        rb.AddForce(knockback, ForceMode.Impulse);

        //------------------------------------------

        Vector3 velAfterForceApplied = new Vector3(rb.velocity.z, 0f, rb.velocity.z);

        uncheckedVelocity = velAfterForceApplied - velBeforeForceApplied;
    }
    
    private void CheckSpeed()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        hasReachedMaxSpeed = flatVel.magnitude > characterInfo.maxSpeed ? true : false;

        //(possibly) temporary code that clamps the speed to the max speed if it goes over
        if (hasReachedMaxSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * characterInfo.maxSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z) + uncheckedVelocity;
        }
    }

    public void TakeKnockback(Vector3 kb)
    {
        //Makes it so that knockback cancels out previous velocity, we can make this toggleable
        knockback = -rb.velocity + kb;
    }
}
