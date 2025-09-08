using TMPro; 
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;


public class BattleSystem : MonoBehaviour
{
    //TODO: Figure out a way to transfer the data of the player 
    public Sprite PlayerSprite;
    public Sprite EnemySprite;

    public SpriteRenderer PlayerRenderer;
    public SpriteRenderer EnemyRenderer;

    public Unit playerUnit;
    public Unit enemyUnit;

    //public TMP_Text playerNameText;
    //public TMP_Text playerHPText;
    //public TMP_Text enemyNameText;
    //public TMP_Text enemyHPText;

    public TMP_Text dialogueText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

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
        PlayerRenderer.sprite = PlayerSprite;
        EnemyRenderer.sprite = EnemySprite; 
        // Set UI

        dialogueText.text = "A wild " + enemyUnit.data.UnitName + " approches...";

        playerHUD.InitHUD(playerUnit);
        enemyHUD.InitHUD(enemyUnit);
        //playerNameText.text = playerUnit.data.unitName;
        //enemyNameText.text = enemyUnit.data.unitName;

        //playerHPText.text = $"{playerUnit.currentHP}/{playerUnit.data.maxHP}";
        //enemyHPText.text = $"{enemyUnit.currentHP}/{enemyUnit.data.maxHP}";

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
        StartCoroutine(PlayerAttack(playerUnit.Damage));
    }

    IEnumerator PlayerAttack(int damage)
    {
        enemyUnit.TakeDamage(damage);
        enemyHUD.DecreaseHP(damage);
        //enemyHPText.text = $"{enemyUnit.currentHP}/{enemyUnit.data.maxHP}";

        yield return new WaitForSeconds(1f);

        if (enemyUnit.IsDead())
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn(enemyUnit.Damage));
        }
    }

    IEnumerator EnemyTurn(int damage)
    {
        yield return new WaitForSeconds(1f);

        playerUnit.TakeDamage(damage);
        playerHUD.DecreaseHP(damage);
        //playerHPText.text = $"{playerUnit.currentHP}/{playerUnit.data.maxHP}";

        yield return new WaitForSeconds(1f);

        if (playerUnit.IsDead())
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
