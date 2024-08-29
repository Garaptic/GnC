using UnityEngine;

public class BossActionHandler : MonoBehaviour
{
    public CardUI firstCardPanel; // UI ������ ��� FirstCard
    public CardUI secondCardPanel; // UI ������ ��� SecondCard
    public CardUI enemyCardPanel; // UI ������ ��� EnemyCard

    public Card firstCard; // 3D ����� FirstCard (Ro)
    public Card secondCard; // 3D ����� SecondCard (Ra)
    public Card enemyCard; // 3D ����� EnemyCard

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
        // ���������� � �������� �������
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
