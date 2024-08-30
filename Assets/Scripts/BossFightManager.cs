using UnityEngine;
using UnityEngine.UI;

public class BossFightManager : MonoBehaviour
{
    public Card firstCard; // 3D ����� FirstCard (Ro)
    public Card secondCard; // 3D ����� SecondCard (Ra)
    public Card enemyCard; // 3D ����� EnemyCard

    public CardUI firstCardPanel; // UI ������ ��� FirstCard
    public CardUI secondCardPanel; // UI ������ ��� SecondCard
    public CardUI enemyCardPanel; // UI ������ ��� EnemyCard

    public Button firstCardAttackButton; // ������ ����� ��� FirstCard
    public Button secondCardAttackButton; // ������ ����� ��� SecondCard
    public Button firstCardDefenseButton; // ������ ������ ��� FirstCard
    public Button secondCardDefenseButton; // ������ ������ ��� SecondCard

    private BossAttackHandler firstCardAttackHandler;
    private BossAttackHandler secondCardAttackHandler;

    void Start()
    {
        firstCardAttackHandler = gameObject.AddComponent<BossAttackHandler>();
        secondCardAttackHandler = gameObject.AddComponent<BossAttackHandler>();

        // ��������� ������������ ����� � ��������� actionValue
        SetupAttackHandler(firstCardAttackHandler, firstCard, secondCard, enemyCard, firstCardPanel, secondCardPanel, enemyCardPanel, 3); // �������� ������ ��������
        SetupAttackHandler(secondCardAttackHandler, secondCard, firstCard, enemyCard, secondCardPanel, firstCardPanel, enemyCardPanel, 4); // �������� ������ ��������

        // ��������� 3D �������� � �����
        firstCardAttackHandler.activeCard = firstCard;
        secondCardAttackHandler.activeCard = secondCard;
        firstCardAttackHandler.targetCard = enemyCard;
        secondCardAttackHandler.targetCard = enemyCard;

        // ��������� ������
        firstCardAttackButton.onClick.AddListener(() => StartBothCardsAction(true));
        secondCardAttackButton.onClick.AddListener(() => StartBothCardsAction(true));
        firstCardDefenseButton.onClick.AddListener(() => StartCardAction(firstCardAttackHandler, firstCard, false));
        secondCardDefenseButton.onClick.AddListener(() => StartCardAction(secondCardAttackHandler, secondCard, false));

        UpdateCardUI();
    }

    private void SetupAttackHandler(BossAttackHandler handler, Card card, Card otherCard, Card enemy, CardUI cardPanel, CardUI otherCardPanel, CardUI enemyPanel, int actionValue)
    {
        handler.firstCard = card;
        handler.secondCard = otherCard;
        handler.enemyCard = enemy;
        handler.firstCardPanel = cardPanel;
        handler.secondCardPanel = otherCardPanel;
        handler.enemyCardPanel = enemyPanel;
        handler.actionValue = actionValue; // ��������� actionValue
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
        if (attackHandler.targetCard == null) // ��������, ��� ����� ���������
        {
            attackHandler.targetCard = enemyCard; // ����� ����� ����� ����
        }

        if (isAttack)
        {
            attackHandler.PerformAction();
            Debug.Log($"{card.cardName} �������!");
        }
        else
        {
            Debug.Log($"{card.cardName} ����������!");
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
        // ������ ����� ����� ��� ������ ����� ������, ���� �����
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
        Debug.Log("������!");
    }

    private void HandleLose()
    {
        Debug.Log("���������...");
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