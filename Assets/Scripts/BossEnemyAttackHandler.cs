using UnityEngine;

public class BossEnemyAttackHandler : BossAttackHandler
{

    private Card lastAttacker; // ��������� ���������

    protected override void Start()
    {
        base.Start();
        actionValue = 8; // ���������, ��� ��� �������� ���������
        cooldown = 1f; // ����� �����������
    }

    public void SetLastAttacker(Card attacker)
    {
        lastAttacker = attacker;
    }

    protected override void OnPerformAction()
    {
        if (targetCard == null || activeCard == null)
        {
            Debug.LogError("Target card or active card is not set.");
            return;
        }

        // ���������� ��������� ���������
        if (lastAttacker != null)
        {
            int damage = Mathf.Max(0, actionValue - lastAttacker.defense);
            targetCard.health -= damage; // ������� ���� �����
            Debug.Log(activeCard.cardName + " ����� " + damage + " ����� " + targetCard.cardName + "! �������� �������� �����: " + targetCard.health);

            if (targetCard.health <= 0)
            {
                targetCard.Die();
            }
        }
        else
        {
            Debug.LogError("Last attacker is not set.");
        }
    }
}
