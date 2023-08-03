using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameManager gm;
    public bool endOfCombat;
    public int EXPgained;

    public bool PlayerTurn;
    public int characterInt;
    public int turnInt;
    public int numberOfPlayerActions;
    public string currentActingCharacter;
    public GameObject currentEnemies;
    public int enemyInt;


    public GameObject playerUI1;
    public GameObject playerUI2;
    public GameObject playerUI3;
    void Start()
    {
        DontDestroyOnLoad(this);
        gm = GameObject.FindObjectOfType<GameManager>();
        currentActingCharacter = gm.currentParty[0].name;
        PlayerTurn = true;
        turnInt = 0;
        enemyInt = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(turnInt >= 3)
        {
            turnInt = 3;
            PlayerTurn = false;
        }

        if (PlayerTurn)
        {

            if (playerUI1.name != currentActingCharacter + "UIA")
            {
                playerUI1.SetActive(false);
            }
            else
            {
                playerUI1.SetActive(true);
            }


            if (playerUI2.name != currentActingCharacter + "UIA")
            {
                playerUI2.SetActive(false);
            }
            else
            {
                playerUI2.SetActive(true);
            }

            if (playerUI3.name != currentActingCharacter + "UIA")
            {
                playerUI3.SetActive(false);
            }
            else
            {
                playerUI3.SetActive(true);
            }
        }
        else
        {
            playerUI1.SetActive(false);
            playerUI2.SetActive(false);
            playerUI3.SetActive(false);
        }

        //debug logic to test functionality
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gm.inCombat = true;
        }

        if (currentEnemies.transform.childCount == 0)
        {
            endOfCombat = true;
            gm.inCombat = false;


        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            EXPgained++;
        }


        
    }
}
