using UnityEngine;

public class BossAttackHandler : BossActionHandler
{
    public Card targetCard; // ������� �����
    public Card activeCard; // �������� �����

    protected override void Start()
    {
        base.Start();
        actionValue = 3; // ��������� ���� �����
        cooldown = 1f; // ����� �����������
    }

    protected override void OnPerformAction()
    {
        if (targetCard == null || enemyCard == null)
        {
            Debug.LogError("Target card or enemy card is not set.");
            return;
        }

        if (targetCard.health > 0)
        {
            int damage = Mathf.Max(0, actionValue - targetCard.defense);
            enemyCard.health -= damage;
            Debug.Log(targetCard.cardName + " ����� " + damage + " ����� �����! �������� �������� �����: " + enemyCard.health);

            if (enemyCard.health <= 0)
            {
                enemyCard.Die();
            }
        }
    }
}
