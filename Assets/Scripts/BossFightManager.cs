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

    private BossAttackHandler firstCardAttackHandler;
    private BossAttackHandler secondCardAttackHandler;

    private Card activeCard;

    void Start()
    {
        firstCardAttackHandler = gameObject.AddComponent<BossAttackHandler>();
        secondCardAttackHandler = gameObject.AddComponent<BossAttackHandler>();

        firstCardAttackHandler.firstCard = firstCard;
        firstCardAttackHandler.secondCard = secondCard;
        firstCardAttackHandler.enemyCard = enemyCard;
        firstCardAttackHandler.firstCardPanel = firstCardPanel;
        firstCardAttackHandler.secondCardPanel = secondCardPanel;
        firstCardAttackHandler.enemyCardPanel = enemyCardPanel;

        secondCardAttackHandler.firstCard = firstCard;
        secondCardAttackHandler.secondCard = secondCard;
        secondCardAttackHandler.enemyCard = enemyCard;
        secondCardAttackHandler.firstCardPanel = firstCardPanel;
        secondCardAttackHandler.secondCardPanel = secondCardPanel;
        secondCardAttackHandler.enemyCardPanel = enemyCardPanel;

        firstCardAttackButton.onClick.AddListener(() => StartCardAction(firstCardAttackHandler, firstCard));
        secondCardAttackButton.onClick.AddListener(() => StartCardAction(secondCardAttackHandler, secondCard));

        UpdateCardUI();
    }

    private void StartCardAction(BossAttackHandler attackHandler, Card card)
    {
        if (activeCard == null)
        {
            activeCard = card;
            attackHandler.targetCard = enemyCard; // Целью атаки будет враг
            attackHandler.PerformAction();

            if (enemyCard.health > 0)
            {
                // Логика атаки врага в ответ
                AttackPlayerCards();
            }

            CheckForWinOrLose();
            UpdateCardUI();
            activeCard = null; // Сброс активной карты
        }
    }

    private void AttackPlayerCards()
    {
        // Логика атаки врага для каждой карты игрока, если нужно
        // В данный момент ничего не делаем, но можно добавить логику атаки
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
        // Дополнительные действия при победе
    }

    private void HandleLose()
    {
        Debug.Log("Поражение...");
        // Дополнительные действия при поражении
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
