using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum battleState { START, PLAYERTURN, ENEMYTURN, WON, LOST };

public class battleManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    unit playerUnit;
    unit enemyUnit;

    public TMP_Text dialogueText;

    public battleHUD playerHUD;
    public battleHUD enemyHUD;

    public battleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = battleState.START;
        StartCoroutine( setupBattle() );
    }

    IEnumerator setupBattle() 
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<unit>();

        dialogueText.text = enemyUnit.unitName + " wants to quiz you...";

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);
        
        state = battleState.PLAYERTURN;
        playerTurn();
    }

    IEnumerator playerAttack()
    {
        int dmgModifier = Random.Range(-4 , +5);
        if (dmgModifier >= +4)
        {
            dialogueText.text = "Your bullshit was super-effective.";
        } else if (dmgModifier < 0)
        {
            dialogueText.text = "Lina doesn't believe you.";
        } else 
        {
            dialogueText.text = "You bullshit a theory seminar.";
        }

        bool isDead = enemyUnit.TakeDamage(playerUnit.damage + dmgModifier);

        if(isDead)
        {
            state = battleState.WON;
            enemyHUD.setHP(enemyUnit.currentHP = 0);
            dialogueText.text = "Lina has feinted.";
            endBattle();
        } else
        {
            state = battleState.ENEMYTURN;
            enemyHUD.setHP(enemyUnit.currentHP);
            yield return new WaitForSeconds(2f);

            StartCoroutine( enemyTurn() );
        }
    }

    IEnumerator playerHeal()
    {
        playerUnit.Heal(15);

        state = battleState.ENEMYTURN;

        playerHUD.setHP(playerUnit.currentHP);
        dialogueText.text = "You consider Lina's questions...";

        yield return new WaitForSeconds(2f);

       StartCoroutine( enemyTurn() ); 

    }


    IEnumerator enemyTurn()
    {
        int dmgModifier = Random.Range(-4 , +5);

        if (dmgModifier >= +4)
        {
            dialogueText.text = "Lina questions the Gods.";
        } else if (dmgModifier < 0)
        {
            dialogueText.text = "Lina asks a simple question.";
        } else 
        {
            dialogueText.text = enemyUnit.unitName + " quizzes you!";
        }
        
        // Move turn token above enemy's head?
        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage (enemyUnit.damage + Random.Range(-4 , +5));
        playerHUD.setHP(playerUnit.currentHP);
        yield return new WaitForSeconds(1f);
        
        if(isDead)
        {
            state = battleState.LOST;
            endBattle();
        } else 
        {
            state = battleState.PLAYERTURN;
            playerTurn();
        }
    }

    void endBattle()
    {
        if (state == battleState.WON)
        {
            dialogueText.text = "You are a great chemist!";
        } else if (state == battleState.LOST)
        {
            dialogueText.text = "Study harder next time.";
        }
    }

    void playerTurn()
    {
        dialogueText.text = "Craft a molecule to attack or heal";
        // Move turn token above player's head?
    }

    public void onAttackButton()
    {
        if (state != battleState.PLAYERTURN)
            return;

        StartCoroutine( playerAttack() );
    }

    public void onHealButton()
    {
        if (state != battleState.PLAYERTURN)
            return;

        StartCoroutine( playerHeal() );
    }
}
