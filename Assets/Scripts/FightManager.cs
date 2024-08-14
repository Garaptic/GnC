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

    public AttackHandler attackHandler;
    public DefenseHandler defenseHandler;

    private bool isAttackButtonEnabled = true;

    void Start()
    {
        InitializeCards();
        InitializeButtons();
    }

    void InitializeCards()
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
    }

    void InitializeButtons()
    {
        attackButton.onClick.RemoveAllListeners();
        attackButton.onClick.AddListener(OnAttackButtonClicked);

        defendButton.onClick.RemoveAllListeners();
        defendButton.onClick.AddListener(OnDefendButtonClicked);
    }

    private void OnAttackButtonClicked()
    {
        if (!isAttackButtonEnabled)
        {
            return;
        }

        // Отключаем кнопку
        isAttackButtonEnabled = false;
        attackButton.interactable = false;

        // Выполняем атаку
        attackHandler.PlayerAttack();

        // Включаем кнопку обратно через 1 секунду
        Invoke(nameof(EnableAttackButton), 1.0f);
    }

    private void OnDefendButtonClicked()
    {
        if (!isAttackButtonEnabled)
        {
            return;
        }

        // Отключаем кнопку
        isAttackButtonEnabled = false;
        attackButton.interactable = false;

        // Выполняем защиту
        defenseHandler.PlayerDefend();

        // Включаем кнопку обратно через 1 секунду
        Invoke(nameof(EnableAttackButton), 1.0f);
    }

    private void EnableAttackButton()
    {
        isAttackButtonEnabled = true;
        attackButton.interactable = true;
    }
}
