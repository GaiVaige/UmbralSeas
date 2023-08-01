using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameManager gm;
    public bool endOfCombat;
    public int EXPgained;

    public bool PlayerTurn;
    public int characterInt;
    public int numberOfPlayerActions;
    public string currentActingCharacter;

    public GameObject playerUI1;
    public GameObject playerUI2;
    public GameObject playerUI3;
    void Start()
    {
        DontDestroyOnLoad(this);
        gm = GameObject.FindObjectOfType<GameManager>();
        currentActingCharacter = gm.currentParty[0].name;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerUI1.name != currentActingCharacter + "UI")
        {
            playerUI1.SetActive(false);
        }
        else
        {
            playerUI1.SetActive(true);
        }


        if (playerUI2.name != currentActingCharacter + "UI")
        {
            playerUI2.SetActive(false);
        }
        else
        {
            playerUI2.SetActive(true);
        }

        if (playerUI3.name != currentActingCharacter + "UI")
        {
            playerUI3.SetActive(false);
        }
        else
        {
            playerUI3.SetActive(true);
        }

        //debug logic to test functionality
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gm.inCombat = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            endOfCombat = true;

        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            EXPgained++;
        }


        
    }
}
