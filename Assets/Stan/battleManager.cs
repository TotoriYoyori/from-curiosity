using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum battleState { START, PLAYERTURN, ENEMYTURN, WON, LOST };

public class battleManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    unit playerUnit;
    unit enemyUnit;

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
        playerGO.GetComponent<unit>();
        Instantiate(enemyPrefab, enemyBattleStation);
    }

}
