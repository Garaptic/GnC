using UnityEngine;

public class BossAttackHandler : BossActionHandler
{
    public Card targetCard; // ������� �����

    protected override void Start()
    {
        base.Start();
        actionValue = 3; // ��������� ���� �����
        cooldown = 1f; // ����� �����������
    }

    protected override void OnPerformAction()
    {
        if (targetCard != null && targetCard.health > 0)
        {
            int damage = Mathf.Max(0, actionValue - targetCard.defense);
            targetCard.health -= damage;
            Debug.Log(firstCard.cardName + " ����� " + damage + " ����� �����! �������� �������� �����: " + enemyCard.health);

            if (targetCard.health <= 0)
            {
                targetCard.Die();
            }
        }
    }

    protected override void UpdateUI()
    {
        base.UpdateUI(); // ��������� UI ������� �����
    }
}