using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*public class PlayerMovement : MonoBehaviour //Defunct (making a physics based player controller no is easy)
{
    public PlayerScript player;
   PlayerID playerInfo;
   PlayerInput playerInput;
   Rigidbody rb;


   //Vector3 velocity;
   Vector3 moveDir;
   public Vector3 acceleration;
   public Vector3 deceleration;
   float decelerationX;
   float decelerationZ;


   public Vector3 v3Velocity;
   public Vector3 playerInputForce;
   public Vector3 playerInputVelocity;
   Vector3 projectedPlayerInputVelocity;
   float turnSmoothVelocity;


   //Debug variables
   public bool hasReachedMaxSpeed;


   // Start is called before the first frame update
   void Start()
   {
       rb = GetComponent<Rigidbody>();
       playerInfo = player.playerID;
       playerInput = player.inputScript;
   }


   // Update is called once per frame
   void Update()
    {
        v3Velocity = rb.velocity;
        moveDir = playerInput.movementInput;

        if (moveDir.magnitude >= 0.1) //turning the head to face the direction it's going
        {
            float targetAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg;
            //Debug.Log(targetAngle); //fix later
            float angle = Mathf.SmoothDamp(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, playerInfo.turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

        //To avoid
        Debug.Log(playerInputVelocity.magnitude);
        if (playerInputVelocity.magnitude !<= playerInfo.maxSpeed)
        {
            Debug.Log("Can Accelerate");
            hasReachedMaxSpeed = false;
            projectedPlayerInputVelocity = playerInputVelocity + playerInfo.acceleration * moveDir * Time.deltaTime;
            if(projectedPlayerInputVelocity.magnitude > playerInfo.maxSpeed)
            {
                //calculate how much acceleration needed to reach max speed and add that instead
            }
            //Put this in an else statement
            acceleration = playerInfo.acceleration * moveDir * Time.deltaTime;
        }
        else
        {
            hasReachedMaxSpeed = true;
            acceleration = Vector3.zero;
            
            //This doesn't work, I need to switch the if statements out to something that measures predicted velocity or something so that 
            //I don't get jank from pressing different combinations of keys :(
            if(moveDir.x * moveDir.z != 0)
            {
                ///<summary> The manual way to maintain the magnitude - uses pythag theorum to change acceleration to the correct
                ///value to maintian the magnitude equal to the max speed. It also maintains the correct direction the player
                ///wants to go and it based on time 
                ///<summary>
                acceleration = new Vector3(Mathf.Sqrt((playerInfo.maxSpeed*playerInfo.maxSpeed)/2) * moveDir.x * Time.deltaTime,
                0f,
                (Mathf.Sqrt((playerInfo.maxSpeed*playerInfo.maxSpeed)/2)) * moveDir.z * Time.deltaTime);
            }
            //This only calls if there's one input and it's in the opposite direction of the movement
            else if (moveDir.x == -Mathf.Sign(playerInputVelocity.x) || moveDir.z == -Mathf.Sign(playerInputVelocity.z))
            {
                acceleration = playerInfo.acceleration * moveDir * Time.deltaTime;
            }
            
        }

        //needs fixing:
        if (moveDir.x == 0 && Mathf.Abs(playerInputVelocity.x) > 0)
        {
            decelerationX = playerInfo.deceleration * (-1 * Mathf.Sign(playerInputVelocity.x) * Time.deltaTime);
        }
        else{
            decelerationX = 0;
        }
        if (moveDir.z == 0 && Mathf.Abs(playerInputVelocity.z) > 0)
        {
            decelerationZ = playerInfo.deceleration * (-1 * Mathf.Sign(playerInputVelocity.z) * Time.deltaTime);
        }
        else{
            decelerationZ = 0;
        }
        
        deceleration = new Vector3(decelerationX, 0f, decelerationZ);
        
        playerInputForce = acceleration + deceleration;
        playerInputVelocity += playerInputForce;
        rb.velocity += playerInputForce;
    }
}*/
