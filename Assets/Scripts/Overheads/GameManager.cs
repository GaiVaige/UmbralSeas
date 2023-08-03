using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool inCombat;
    public GameObject combatUI;
    public GameObject[] currentParty;
    public CombatManager cm;
    public CharacterValues Verd;
    public CharacterValues Cors;
    public CharacterValues Loga;


    void Start()
    {
        DontDestroyOnLoad(this);
        combatUI = GameObject.Find("CombatUI");
        combatUI.SetActive(false);

        cm = FindObjectOfType<CombatManager>();
        Verd = GameObject.Find("Verdstalt").GetComponent<CharacterValues>();
        Cors = GameObject.Find("Corsola").GetComponent<CharacterValues>();
        Loga = GameObject.Find("Logan").GetComponent<CharacterValues>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inCombat)
        {
            combatUI.SetActive(true);
        }
        else
        {
            combatUI.SetActive(false);
        }

        if(Verd.hasRun && Cors.hasRun && Loga.hasRun)
        {
            cm.EXPgained = 0;
        }
    }
}
