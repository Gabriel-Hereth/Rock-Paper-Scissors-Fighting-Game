using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Player Scripts")]
    public PlayerID playerID;
    public CharacterID characterID;

    public PlayerInput inputScript;
    public PlayerMovement3 movementScript;
    public PlayerAbilities abilityScript;

    GameObject gameManager;

    [Header("Events")]
    public GameEvent onPlayerDamaged;

    //Player info
    public int health;

    private void Start() 
    {
        //IMPORTANT: This needs to work for both players - it currently does not
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        characterID = gameManager.GetComponent<GmaeManager>().player1Character;
    }

    public void TakeDamage(int damage)
    {
        //Parameters for this event can be used for identification and data transfer (Component, Object)
        onPlayerDamaged.Raise(this, 0);
        health -= damage;
    }
}
