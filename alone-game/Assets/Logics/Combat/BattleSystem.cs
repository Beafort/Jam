using TMPro; // for TextMeshPro
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleSystem : MonoBehaviour
{
    public Unit playerPrefab;
    public Unit enemyPrefab;

    Unit playerUnit;
    Unit enemyUnit;

    public TMP_Text playerNameText;
    public TMP_Text playerHPText;
    public TMP_Text enemyNameText;
    public TMP_Text enemyHPText;

    public Button attackButton;

    public BattleState state;

    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        // Spawn units
        playerUnit = Instantiate(playerPrefab);
        enemyUnit = Instantiate(enemyPrefab);

        // Set UI
        playerNameText.text = playerUnit.data.unitName;
        enemyNameText.text = enemyUnit.data.unitName;

        playerHPText.text = $"{playerUnit.currentHP}/{playerUnit.data.maxHP}";
        enemyHPText.text = $"{enemyUnit.currentHP}/{enemyUnit.data.maxHP}";

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        attackButton.interactable = true;
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN) return;

        attackButton.interactable = false;
        StartCoroutine(PlayerAttack());
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.data.damage);
        enemyHPText.text = $"{enemyUnit.currentHP}/{enemyUnit.data.maxHP}";

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.data.damage);
        playerHPText.text = $"{playerUnit.currentHP}/{playerUnit.data.maxHP}";

        yield return new WaitForSeconds(1f);

        if (isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
            Debug.Log("You won the battle!");
        else if (state == BattleState.LOST)
            Debug.Log("You lost the battle...");
    }
}
