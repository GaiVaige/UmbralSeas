using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public string characterName;
    public GameObject thisCharacterObject;
    public CombatManager cm;
    public GameManager gm;
    public CharacterValues thisCharacter;
    public GameObject target;
    public EnemyStats es;

    // Start is called before the first frame update
    void Start()
    {

        cm = FindObjectOfType<CombatManager>();
        cm.characterInt = 0;
        gm = FindObjectOfType<GameManager>();
        target = GameObject.Find("Enemy");
        es = target.GetComponentInChildren<EnemyStats>();

        thisCharacterObject = GameObject.Find(characterName);

        if(thisCharacterObject != null)
        {
            Debug.Log("Successfully found object for character " + characterName);
        }
        else
        {
            Debug.Log("Did not find object for character " + characterName + ". Did you spell it wrong?");
        }

        thisCharacter = thisCharacterObject.GetComponent<CharacterValues>();
    }


    public void Update()
    {
        if (target == null && gm.inCombat)
        {
            target = FindObjectOfType<EnemyStats>().gameObject;
            
        }

        if(es == null && gm.inCombat)
        {
            es = target.GetComponentInChildren<EnemyStats>();
        }
    }

    // Update is called once per frame
    public void BasicAttack()
    {

        es.currentHP -= 10 + 10 * thisCharacter.ATK / 5;
        cm.turnInt++;


        if (cm.characterInt < 2)
        {
            cm.characterInt++;
        }
        else
        {
            cm.characterInt = 0;
        }
        cm.currentActingCharacter = gm.currentParty[cm.characterInt].name;
    }
}
