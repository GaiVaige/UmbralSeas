using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStats : MonoBehaviour
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
    public int givenEXP;
    public CombatManager cm;
    public GameManager gm;
    public GameObject partyHolder;
    public CharacterValues[] partyMembers;


    // Start is called before the first frame update
    void Start()
    {
        cm = FindObjectOfType<CombatManager>();
        gm = FindObjectOfType<GameManager>();

        partyHolder = GameObject.Find("PartyHolder");
        partyMembers = partyHolder.GetComponentsInChildren<CharacterValues>();
    }
}
