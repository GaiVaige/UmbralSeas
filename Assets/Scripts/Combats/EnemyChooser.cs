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
    public CombatManager cm;
    public GameObject enemyValues;
    public string enemyName;
    public int enemyHPRefresh;
    public TMP_Text enemyHP;

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

        

        currentThreat = cm.currentActingCharacter;
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

    public void SetTarget()
    {
        attackingCharScript.target = this.gameObject;

        attackingCharScript.es = attackingCharScript.target.GetComponentInChildren<EnemyStats>();

    }
}
