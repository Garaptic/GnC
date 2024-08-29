using UnityEngine;

public class BossActionHandler : MonoBehaviour
{
    public CardUI firstCardPanel; // UI панель для FirstCard
    public CardUI secondCardPanel; // UI панель для SecondCard
    public CardUI enemyCardPanel; // UI панель для EnemyCard

    public Card firstCard; // 3D карта FirstCard (Ro)
    public Card secondCard; // 3D карта SecondCard (Ra)
    public Card enemyCard; // 3D карта EnemyCard

    public int actionValue;
    public float cooldown = 0;
    protected float timer = 0;

    protected virtual void Start()
    {
        timer = cooldown;
    }

    protected virtual void Update()
    {
        timer += Time.deltaTime;
    }

    public virtual void PerformAction()
    {
        if (timer > cooldown)
        {
            OnPerformAction();
            timer = 0;
            UpdateUI();
        }
    }

    protected virtual void OnPerformAction()
    {
        // Реализация в дочерних классах
    }

    protected virtual void UpdateUI()
    {
        if (firstCardPanel != null && firstCard != null)
        {
            firstCardPanel.UpdateUI(firstCard);
        }

        if (secondCardPanel != null && secondCard != null)
        {
            secondCardPanel.UpdateUI(secondCard);
        }

        if (enemyCardPanel != null && enemyCard != null)
        {
            enemyCardPanel.UpdateUI(enemyCard);
        }
    }
}
