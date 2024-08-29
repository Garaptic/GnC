using UnityEngine;
using UnityEngine.UI;

public class BossFightManager : MonoBehaviour
{
    public Card firstCard; // 3D карта FirstCard (Ro)
    public Card secondCard; // 3D карта SecondCard (Ra)
    public Card enemyCard; // 3D карта EnemyCard

    public CardUI firstCardPanel; // UI панель для FirstCard
    public CardUI secondCardPanel; // UI панель для SecondCard
    public CardUI enemyCardPanel; // UI панель для EnemyCard

    public Button firstCardAttackButton; // Кнопка атаки для FirstCard
    public Button secondCardAttackButton; // Кнопка атаки для SecondCard
    public Button firstCardDefenseButton; // Кнопка защиты для FirstCard
    public Button secondCardDefenseButton; // Кнопка защиты для SecondCard

    private BossAttackHandler firstCardAttackHandler;
    private BossAttackHandler secondCardAttackHandler;

    void Start()
    {
        firstCardAttackHandler = gameObject.AddComponent<BossAttackHandler>();
        secondCardAttackHandler = gameObject.AddComponent<BossAttackHandler>();

        // Настройка обработчиков атаки
        SetupAttackHandler(firstCardAttackHandler, firstCard, secondCard, enemyCard, firstCardPanel, secondCardPanel, enemyCardPanel);
        SetupAttackHandler(secondCardAttackHandler, secondCard, firstCard, enemyCard, secondCardPanel, firstCardPanel, enemyCardPanel);

        // Настройка кнопок
        firstCardAttackButton.onClick.AddListener(() => StartBothCardsAction(true));
        secondCardAttackButton.onClick.AddListener(() => StartBothCardsAction(true));
        firstCardDefenseButton.onClick.AddListener(() => StartCardAction(firstCardAttackHandler, firstCard, false));
        secondCardDefenseButton.onClick.AddListener(() => StartCardAction(secondCardAttackHandler, secondCard, false));

        UpdateCardUI();
    }

    private void SetupAttackHandler(BossAttackHandler handler, Card card, Card otherCard, Card enemy, CardUI cardPanel, CardUI otherCardPanel, CardUI enemyPanel)
    {
        handler.firstCard = card;
        handler.secondCard = otherCard;
        handler.enemyCard = enemy;
        handler.firstCardPanel = cardPanel;
        handler.secondCardPanel = otherCardPanel;
        handler.enemyCardPanel = enemyPanel;
    }

    private void StartBothCardsAction(bool isAttack)
    {
        if (firstCard != null && secondCard != null)
        {
            StartCardAction(firstCardAttackHandler, firstCard, isAttack);
            StartCardAction(secondCardAttackHandler, secondCard, isAttack);
        }
    }

    private void StartCardAction(BossAttackHandler attackHandler, Card card, bool isAttack)
    {
        if (attackHandler.targetCard == null) // Убедимся, что карта назначена
        {
            attackHandler.targetCard = enemyCard; // Целью атаки будет враг
        }

        if (isAttack)
        {
            attackHandler.PerformAction();
            Debug.Log($"{card.cardName} атакует!");
        }
        else
        {
            Debug.Log($"{card.cardName} защищается!");
        }

        if (enemyCard.health > 0)
        {
            AttackPlayerCards();
        }

        CheckForWinOrLose();
        UpdateCardUI();
    }

    private void AttackPlayerCards()
    {
        // Логика атаки врага для каждой карты игрока, если нужно
    }

    private void CheckForWinOrLose()
    {
        if (enemyCard.health <= 0)
        {
            HandleWin();
        }
        else if (firstCard.health <= 0 && secondCard.health <= 0)
        {
            HandleLose();
        }
    }

    private void HandleWin()
    {
        Debug.Log("Победа!");
    }

    private void HandleLose()
    {
        Debug.Log("Поражение...");
    }

    private void UpdateCardUI()
    {
        if (firstCard != null && firstCardPanel != null)
        {
            firstCardPanel.UpdateUI(firstCard);
        }

        if (secondCard != null && secondCardPanel != null)
        {
            secondCardPanel.UpdateUI(secondCard);
        }

        if (enemyCard != null && enemyCardPanel != null)
        {
            enemyCardPanel.UpdateUI(enemyCard);
        }
    }
}
