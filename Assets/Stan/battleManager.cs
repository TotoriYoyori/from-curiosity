using System.Collections;
using System.Collections.Generic;
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

    public battleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = battleState.START;
        setupBattle();
    }

    void setupBattle() 
    {
        GameObject playerGO = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGO.GetComponent<unit>();

        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<unit>();

        dialogueText.text = "A wild " + enemyUnit.unitName + " approaches...";
    }

}
