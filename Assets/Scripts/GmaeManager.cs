using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GmaeManager : MonoBehaviour
{
    enum characterIndexes{
        rock,
        paper,
        scissors
    }



    [Header("Player and Character IDs")]
    public CharacterID[] characterIDs;
    public PlayerID playerInfo1;
    public PlayerID playerInfo2;
    public CharacterID player1Character;
    public CharacterID player2Character;

    [Header("Player Management")]
    public int characterSelected1 = 0;
    public int characterSelected2 = 0;

    public GameObject player1Prefab;
    public Transform player1SpawnPoint;

    [Header("UI Elements")]
    public TextMeshProUGUI timeText;
    public Texture2D[] characterSelectionIcons;
    public GameObject characterIndicator1, characterIndicator2;
    public GameObject playMenu, startMenu;

    [Header("The Rest")]
    public float characterSelectionTimer;
    public string player1Selection, player2Selection;

    //Checkpoints
    bool gameStarted;
    bool characterSelected;
    bool fightStarted;


    public void Play()
    {
        playMenu.SetActive(false);
        startMenu.SetActive(true);
        gameStarted = true;
    }

    public void Update()
    {
        //These are being called every frame regardless of if it needs to be, although it barely matters, it's still something to think about
        if (gameStarted && !characterSelected){
            characterSelection();
        }
        if (characterSelected && !fightStarted){
            StartFight();
        }
    }



    void characterSelection()
    {
        characterSelectionTimer -= Time.deltaTime;
        if (characterSelectionTimer <= 0)
        {
            startMenu.SetActive(false);
            //chaveVideo.SetActive(false);
            characterSelected = true;
        }

        float displayTime;
        displayTime = Mathf.Round(characterSelectionTimer * 100)/ 100;
        timeText.text = displayTime.ToString();

        if (Input.GetKeyDown(playerInfo1.lefwardKey))
        {
            characterSelected1 = (int)characterIndexes.rock;
            player1Selection = "rock";
        }
        if (Input.GetKeyDown(playerInfo1.backwardKey))
        {
            characterSelected1 = (int)characterIndexes.paper;
            player1Selection = "paper";
        }
        if (Input.GetKeyDown(playerInfo1.rightwardKey))
        {
            characterSelected1 = (int)characterIndexes.scissors;
            player1Selection = "scissors";
        }
        characterIndicator1.GetComponent<RawImage>().texture = characterSelectionIcons[characterSelected1];
        player1Character = characterIDs[characterSelected1];


        if (Input.GetKeyDown(playerInfo2.lefwardKey))
        {
            characterSelected2 = (int)characterIndexes.rock;
            player2Selection = "rock";
        }
        if (Input.GetKeyDown(playerInfo2.backwardKey))
        {
            characterSelected2 = (int)characterIndexes.paper;
            player2Selection = "paper";
        }
        if (Input.GetKeyDown(playerInfo2.rightwardKey))
        {
            characterSelected2 = (int)characterIndexes.scissors;
             player2Selection = "scissors";
        }
        characterIndicator2.GetComponent<RawImage>().texture = characterSelectionIcons[characterSelected2];
        player2Character = characterIDs[characterSelected2];
        
    }

    void StartFight()
    {
        fightStarted = true;
        SpawnPlayers();
    }

    void SpawnPlayers()
    {
        //IMPORTANT - ONLY WORKS FOR ONE PLAYER (fix that)
        Instantiate(player1Prefab, player1SpawnPoint.position, player1SpawnPoint.rotation);
    }
}