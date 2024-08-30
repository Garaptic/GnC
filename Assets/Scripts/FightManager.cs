using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // �� �������� �������� ���� ������ ��� ���������� �������

public class FightManager : MonoBehaviour
{
    public Card playerCard;
    public Card enemyCard;

    public CardUI playerCardUI;
    public CardUI enemyCardUI;

    public Button attackButton;
    public Button defendButton; // ������ ������

    private AttackHandler attackHandler;
    private DefenseHandler defenseHandler;
    private EnemyAttackHandler enemyAttackHandler; // ����� �����

    void Start()
    {
        // �������������
        attackHandler = GetComponentInChildren<AttackHandler>();
        defenseHandler = GetComponentInChildren<DefenseHandler>();
        enemyAttackHandler = GetComponentInChildren<EnemyAttackHandler>();

        attackButton.onClick.AddListener(OnAttackButtonClicked);
        defendButton.onClick.AddListener(OnDefendButtonClicked);

        // ��������� UI � ������
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

    public void OnAttackButtonClicked()
    {
        attackHandler.targetCard = enemyCard;
        attackHandler.PerformAction();
        CheckForWinOrLose(); // ��������� ������ ��� ��������� ����� �����

        if (enemyCard.health > 0)
        {
            EndTurn(); // ��������� ���, ����� ���� ��������
        }
    }
    public void OnDefendButtonClicked()
    {
        defenseHandler.playerCard = playerCard; // ������������� ������ � DefenseHandler
        defenseHandler.PerformAction();
        EndTurn(); // ��������� ���, ����� ���� ��������
    }

    private void EndTurn()
    {
        if (enemyCard.health > 0)
        {
            enemyAttackHandler.targetCard = playerCard;
            enemyAttackHandler.PerformAction();
            CheckForWinOrLose(); // ��������� ������ ��� ��������� ����� ����� �����
        }

        // ���������� ������ ����� ���������� ���� �����
        playerCard.defense = 0;

        UpdateCardUI(); // ��������� UI ����� ��������
    }

    private void CheckForWinOrLose()
    {
        if (enemyCard.health <= 0)
        {
            HandleWin();
        }
        else if (playerCard.health <= 0)
        {
            HandleLose();
        }
    }

    private void HandleWin()
    {
        Debug.Log("������!");
        SceneManager.LoadScene("GnC"); // ���������� ������ �� �������� ����� ����� ������
    }

    private void HandleLose()
    {
        Debug.Log("���������...");
        SceneManager.LoadScene("Menu"); // ��������� ����� ���������
    }

    private void UpdateCardUI()
    {
        playerCardUI.UpdateUI(playerCard);
        enemyCardUI.UpdateUI(enemyCard);
    }
}