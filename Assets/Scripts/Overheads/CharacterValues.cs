using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterValues : MonoBehaviour
{
    public string Name;
    public int maxHP;
    public int currentHP;
    public int maxFP;
    public int currentFP;
    public int ATK;
    public int DEF;
    public int MATK;
    public int MDEF;
    public int Level;
    public float levelRate;
    public float levelEXPreq;
    public int currentEXP;
    public int partyNumber;


    [Header("Lockouts for Calcs")]
    public bool hasRun;
    public CombatManager cm;

    public GameManager gm;

    public void Start()
    {
        cm = FindObjectOfType<CombatManager>();
        gm = FindObjectOfType<GameManager>();
        AddToParty();
        levelEXPreq = currentEXP + 50 * (levelRate + Level/5);
    }

    // Update is called once per frame
    void Update()
    {
        RunCalcsLeveling();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            AddToParty();
        }
    }



    public void RunCalcsLeveling()
    {
        if(cm.endOfCombat == true)
        {
            currentEXP += cm.EXPgained;
            cm.endOfCombat = false;
            hasRun = true;
        }


        if(hasRun == true)
        {
            cm.endOfCombat = false;
            cm.EXPgained = 0;
            hasRun = false;
        }

        if(currentEXP >= levelEXPreq)
        {
            Level++;
            levelEXPreq += 50 * (levelRate + Level/5);
        }
    }

    public void AddToParty()
    {
        gm.currentParty[partyNumber] = this.gameObject;
    }
}
