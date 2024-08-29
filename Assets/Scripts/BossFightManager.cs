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
            attackHandler.targetCard = enemyCard; // ����� ����� ����� ����
            attackHandler.PerformAction();

            if (enemyCard.health > 0)
            {
                // ������ ����� ����� � �����
                AttackPlayerCards();
            }

            CheckForWinOrLose();
            UpdateCardUI();
            activeCard = null; // ����� �������� �����
        }
    }

    private void AttackPlayerCards()
    {
        // ������ ����� ����� ��� ������ ����� ������, ���� �����
        // � ������ ������ ������ �� ������, �� ����� �������� ������ �����
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
        // �������������� �������� ��� ������
    }

    private void HandleLose()
    {
        Debug.Log("���������...");
        // �������������� �������� ��� ���������
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
