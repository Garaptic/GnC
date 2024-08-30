using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossFightManager : MonoBehaviour
{
    public Card firstCard;
    public Card secondCard;
    public Card enemyCard;

    public CardUI firstCardPanel;
    public CardUI secondCardPanel;
    public CardUI enemyCardPanel;

    public Button firstCardAttackButton;
    public Button secondCardAttackButton;
    public Button firstCardDefenseButton;
    public Button secondCardDefenseButton;

    private BossAttackHandler firstCardAttackHandler;
    private BossAttackHandler secondCardAttackHandler;
    private BossEnemyAttackHandler enemyAttackHandler;

    private Card lastAttackingCard; // �������� ��������� ��������� �����

    void Start()
    {
        firstCardAttackHandler = gameObject.AddComponent<BossAttackHandler>();
        secondCardAttackHandler = gameObject.AddComponent<BossAttackHandler>();
        enemyAttackHandler = gameObject.AddComponent<BossEnemyAttackHandler>();

        // ��������� �������� ActionValue
        firstCardAttackHandler.actionValue = 3;
        secondCardAttackHandler.actionValue = 4;

        // ��������� ������������ �����
        SetupAttackHandler(firstCardAttackHandler, firstCard, secondCard, enemyCard, firstCardPanel, secondCardPanel, enemyCardPanel);
        SetupAttackHandler(secondCardAttackHandler, secondCard, firstCard, enemyCard, secondCardPanel, firstCardPanel, enemyCardPanel);

        // ��������� ����������� ����� �����
        SetupEnemyAttackHandler(enemyAttackHandler, enemyCard, enemyCardPanel, firstCard, firstCardPanel, secondCard, secondCardPanel);

        // ��������� 3D �������� � �����
        firstCardAttackHandler.activeCard = firstCard;
        secondCardAttackHandler.activeCard = secondCard;
        firstCardAttackHandler.targetCard = enemyCard;
        secondCardAttackHandler.targetCard = enemyCard;

        // ��������� ������
        firstCardAttackButton.onClick.AddListener(() => StartCardAction(firstCardAttackHandler, firstCard, true));
        secondCardAttackButton.onClick.AddListener(() => StartCardAction(secondCardAttackHandler, secondCard, true));
        firstCardDefenseButton.onClick.AddListener(() => StartCardAction(firstCardAttackHandler, firstCard, false));
        secondCardDefenseButton.onClick.AddListener(() => StartCardAction(secondCardAttackHandler, secondCard, false));

        UpdateCardUI();
    }

    void Update()
    {
        // ���� ���������� ��������
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

    private void SetupAttackHandler(BossAttackHandler handler, Card card, Card otherCard, Card enemy, CardUI cardPanel, CardUI otherCardPanel, CardUI enemyPanel)
    {
        handler.firstCard = card;
        handler.secondCard = otherCard;
        handler.enemyCard = enemy;
        handler.firstCardPanel = cardPanel;
        handler.secondCardPanel = otherCardPanel;
        handler.enemyCardPanel = enemyPanel;
    }

    private void SetupEnemyAttackHandler(BossEnemyAttackHandler handler, Card enemy, CardUI enemyPanel, Card firstCard, CardUI firstCardPanel, Card secondCard, CardUI secondCardPanel)
    {
        handler.enemyCard = enemy;
        handler.enemyCardPanel = enemyPanel;
        handler.firstCard = firstCard;
        handler.firstCardPanel = firstCardPanel;
        handler.secondCard = secondCard;
        handler.secondCardPanel = secondCardPanel;

        // ��������� �������� ����� �����
        handler.activeCard = enemy; // ���������, ��� ��� 3D ������ �����
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

            // ��������� ��������� ��������� ����� ��� �����
            if (attackHandler is BossAttackHandler bossAttackHandler)
            {
                lastAttackingCard = card; // ���������� ��������� ��������� �����
                if (enemyAttackHandler != null)
                {
                    enemyAttackHandler.SetLastAttacker(card);
                }
            }
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
        if (enemyCard.health > 0)
        {
            if (lastAttackingCard != null)
            {
                enemyAttackHandler.targetCard = lastAttackingCard; // ������������� ���� ����� �����
                Debug.Log($"���� ������� {lastAttackingCard.cardName}");
                enemyAttackHandler.PerformAction();
            }
            else
            {
                Debug.LogError("Last attacking card is not set.");
            }
        }
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
        SceneManager.LoadScene("GnC");
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
