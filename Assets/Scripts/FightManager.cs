using UnityEngine;
using UnityEngine.UI;

public class FightManager : MonoBehaviour
{
    public Card playerCard;
    public Card enemyCard;

    public CardUI playerCardUI;
    public CardUI enemyCardUI;

    public Button attackButton;
    public Button defendButton;

    private bool isDefending = false;

    void Start()
    {
        playerCard.cardName = "Roundy";
        playerCard.health = 50;
        playerCard.strength = 3;
        playerCard.defense = 3;

        enemyCard.cardName = "Raydes";
        enemyCard.health = 50;
        enemyCard.strength = 4;
        enemyCard.defense = 7;

        playerCardUI.SetCard(playerCard);
        enemyCardUI.SetCard(enemyCard);

        attackButton.onClick.AddListener(PlayerAttack);
        defendButton.onClick.AddListener(PlayerDefend);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void PlayerAttack()
    {
        int damage = playerCard.strength;
        if (isDefending)
        {
            damage = Mathf.Max(0, playerCard.strength - enemyCard.defense);
            isDefending = false; // Сбрасываем защиту
        }

        enemyCard.health -= damage;
        enemyCardUI.UpdateUI();

        if (enemyCard.health <= 0)
        {
            CheckFightEnd();
            return;
        }

        EnemyTurn();
    }

    public void PlayerDefend()
    {
        isDefending = true;
        EnemyTurn(); // После защиты враг атакует
    }

    void EnemyTurn()
    {
        int damage = enemyCard.strength;
        if (isDefending)
        {
            damage = Mathf.Max(0, enemyCard.strength - playerCard.defense);
            isDefending = false; // Сбрасываем защиту
        }

        playerCard.health -= damage;
        playerCardUI.UpdateUI();

        CheckFightEnd();
    }

    void CheckFightEnd()
    {
        if (playerCard.health <= 0)
        {
            Debug.Log("Игрок проиграл!");
        }
        else if (enemyCard.health <= 0)
        {
            Debug.Log("Игрок победил!");
        }
    }
}