using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.GraphicsBuffer;

public class EnemyChooser : MonoBehaviour
{
    public GameObject attackingCharacter;
    public string currentThreat;
    public PlayerCombat attackingCharScript;
    public CharacterValues playerHealth;
    public CombatManager cm;
    public GameObject enemyValues;
    public string enemyName;
    public int enemyHPRefresh;
    public TMP_Text enemyHP;
    public bool hasAttacked;
    public EnemyStats es;


    [Header("AI Behaviours")]
    public bool totalRandom;
    public int totalRandomOutput;
    public bool targetWeakest;

    public void Start()
    {

        cm = FindObjectOfType<CombatManager>();
        currentThreat = cm.currentActingCharacter;

        Instantiate(enemyValues, this.gameObject.transform);
        enemyValues.name = enemyName;
        enemyHP = GetComponentInChildren<TMP_Text>();
        enemyHP.text = enemyValues.GetComponent<EnemyStats>().currentHP.ToString();
        enemyHPRefresh = enemyValues.GetComponent<EnemyStats>().currentHP;

    }


    public void Update()
    {

        if(GetComponentInChildren<EnemyStats>().currentHP <= 0)
        {
                cm.EXPgained += GetComponentInChildren<EnemyStats>().givenEXP;
                Destroy(this.gameObject);
        }


            currentThreat = cm.currentActingCharacter;



        if (cm.PlayerTurn)
        {
            if (attackingCharacter == null || attackingCharScript == null)
            {
                attackingCharacter = GameObject.Find(currentThreat + "UI");
                attackingCharScript = attackingCharacter.GetComponent<PlayerCombat>();
            }






            if (attackingCharacter.name != currentThreat + "UI")
            {
                attackingCharacter = GameObject.Find(currentThreat + "UI");

            }

            enemyHPRefresh = GetComponentInChildren<EnemyStats>().currentHP;
            enemyHP.text = enemyHPRefresh.ToString();
        }
        else
        {
            if (totalRandom && !hasAttacked)
            {
                totalRandomOutput = Random.Range(0, 3);

                if(totalRandomOutput == 0)
                {
                    attackingCharacter = GameObject.Find("VerdstaltUI");
                    attackingCharScript = attackingCharacter.GetComponent<PlayerCombat>();
                    playerHealth = attackingCharScript.thisCharacter;
                    BasicAttack();
                }

                if (totalRandomOutput == 1)
                {
                    attackingCharacter = GameObject.Find("CorsolaUI");
                    attackingCharScript = attackingCharacter.GetComponent<PlayerCombat>();
                    playerHealth = attackingCharScript.thisCharacter;
                    BasicAttack();
                }

                if (totalRandomOutput == 2)
                {
                    attackingCharacter = GameObject.Find("LoganUI");
                    attackingCharScript = attackingCharacter.GetComponent<PlayerCombat>();
                    playerHealth = attackingCharScript.thisCharacter;
                    BasicAttack();
                }

            }
            else if (hasAttacked)
            {
                cm.turnInt = 0;
                cm.PlayerTurn = true;
            }
        }

    }

    public void SetTarget()
    {
        attackingCharScript.target = this.gameObject;

        attackingCharScript.es = attackingCharScript.target.GetComponentInChildren<EnemyStats>();

    }

    public void BasicAttack()
    {
        es = GetComponentInChildren<EnemyStats>();
        playerHealth.currentHP -= 10 + 10 * es.ATK / 5;
        hasAttacked = true;
    }
}
