using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Не забудьте добавить этот импорт для управления сценами

public class FightManager : MonoBehaviour
{
    public Card playerCard;
    public Card enemyCard;

    public CardUI playerCardUI;
    public CardUI enemyCardUI;

    public Button attackButton;
    public Button defendButton; // Кнопка защиты

    private AttackHandler attackHandler;
    private DefenseHandler defenseHandler;
    private EnemyAttackHandler enemyAttackHandler; // Атака врага

    void Start()
    {
        // Инициализация
        attackHandler = GetComponentInChildren<AttackHandler>();
        defenseHandler = GetComponentInChildren<DefenseHandler>();
        enemyAttackHandler = GetComponentInChildren<EnemyAttackHandler>();

        attackButton.onClick.AddListener(OnAttackButtonClicked);
        defendButton.onClick.AddListener(OnDefendButtonClicked);

        // Обновляем UI в начале
        UpdateCardUI();
    }

    void Update()
    {
        // Блок управления курсором
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
        CheckForWinOrLose(); // Проверяем победу или поражение после атаки

        if (enemyCard.health > 0)
        {
            EndTurn(); // Завершаем ход, чтобы враг атаковал
        }
    }
    public void OnDefendButtonClicked()
    {
        defenseHandler.playerCard = playerCard; // Устанавливаем игрока в DefenseHandler
        defenseHandler.PerformAction();
        EndTurn(); // Завершаем ход, чтобы враг атаковал
    }

    private void EndTurn()
    {
        if (enemyCard.health > 0)
        {
            enemyAttackHandler.targetCard = playerCard;
            enemyAttackHandler.PerformAction();
            CheckForWinOrLose(); // Проверяем победу или поражение после атаки врага
        }

        // Сбрасываем защиту после выполнения хода врага
        playerCard.defense = 0;

        UpdateCardUI(); // Обновляем UI после действий
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
        Debug.Log("Победа!");
        SceneManager.LoadScene("GnC"); // Возвращаем игрока на основную сцену после победы
    }

    private void HandleLose()
    {
        Debug.Log("Поражение...");
        SceneManager.LoadScene("Menu"); // Загружаем сцену поражения
    }

    private void UpdateCardUI()
    {
        playerCardUI.UpdateUI(playerCard);
        enemyCardUI.UpdateUI(enemyCard);
    }
}