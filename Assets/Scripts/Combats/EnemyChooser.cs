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

    public EnemyChooser[] currentEnemies;
    public EnemyChooser currentAttackingEnemy;
    public bool canAttack;


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
        currentEnemies = FindObjectsOfType<EnemyChooser>();
        currentAttackingEnemy = currentEnemies[cm.enemyInt];

    }


    public void Update()
    {
        if(cm.enemyInt >= currentEnemies.Length)
        {
            cm.PlayerTurn = true;
            cm.turnInt = 0;
            cm.enemyInt = 0;
        }

        if (currentAttackingEnemy == null)
        {
            currentEnemies = FindObjectsOfType<EnemyChooser>();
        }

        currentAttackingEnemy = currentEnemies[cm.enemyInt];


        if(currentAttackingEnemy.gameObject == this.gameObject)
        {
            canAttack = true;
        }




        if(GetComponentInChildren<EnemyStats>().currentHP <= 0)
        {
                cm.EXPgained += GetComponentInChildren<EnemyStats>().givenEXP;
                Destroy(this.gameObject);
        }


            currentThreat = cm.currentActingCharacter;


        enemyHPRefresh = GetComponentInChildren<EnemyStats>().currentHP;
        enemyHP.text = enemyHPRefresh.ToString();


        if (cm.PlayerTurn)
        {

            hasAttacked = false;
            if (attackingCharacter == null || attackingCharScript == null)
            {
                attackingCharacter = GameObject.Find(currentThreat + "UI");
                attackingCharScript = attackingCharacter.GetComponent<PlayerCombat>();
            }






            if (attackingCharacter.name != currentThreat + "UI")
            {
                attackingCharacter = GameObject.Find(currentThreat + "UI");
                attackingCharScript = attackingCharacter.GetComponent<PlayerCombat>();

            }


        }
        else if(!cm.PlayerTurn)
        {
            if (totalRandom && !hasAttacked)
            {
                totalRandomOutput = Random.Range(0, 3);

                if(totalRandomOutput == 0 && canAttack)
                {
                    attackingCharacter = GameObject.Find("VerdstaltUI");
                    attackingCharScript = attackingCharacter.GetComponent<PlayerCombat>();
                    playerHealth = attackingCharScript.thisCharacter;
                    BasicAttack();
                    StartCoroutine(WaitForAttack());
                }

                if (totalRandomOutput == 1 && canAttack)
                {
                    attackingCharacter = GameObject.Find("CorsolaUI");
                    attackingCharScript = attackingCharacter.GetComponent<PlayerCombat>();
                    playerHealth = attackingCharScript.thisCharacter;
                    BasicAttack();
                    StartCoroutine(WaitForAttack());
                }

                if (totalRandomOutput == 2 && canAttack)
                {
                    attackingCharacter = GameObject.Find("LoganUI");
                    attackingCharScript = attackingCharacter.GetComponent<PlayerCombat>();
                    playerHealth = attackingCharScript.thisCharacter;
                    BasicAttack();
                    StartCoroutine(WaitForAttack());

                }

            }
            else if (hasAttacked)
            {
                cm.turnInt = 0;
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
        Debug.Log(this.gameObject.name + " has attacked!");
        hasAttacked = true;

    }

    public IEnumerator WaitForAttack()
    {
        yield return new WaitForSeconds(2f);
        cm.enemyInt++;
    }

}
