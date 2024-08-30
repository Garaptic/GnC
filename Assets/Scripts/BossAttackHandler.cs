using UnityEngine;

public class BossAttackHandler : BossActionHandler
{
    public Card targetCard; // ������� ����� (����)
    public Card activeCard; // �������� ����� (�����)

    protected override void Start()
    {
        base.Start();
        cooldown = 1f; // ����� �����������
    }

    protected override void OnPerformAction()
    {
        if (targetCard == null || activeCard == null)
        {
            Debug.LogError("Target card or active card is not set.");
            return;
        }

        if (targetCard.health > 0)
        {
            int damage = Mathf.Max(0, actionValue - targetCard.defense);
            targetCard.health -= damage; // ������� ���� �����
            Debug.Log(activeCard.cardName + " ����� " + damage + " ����� " + targetCard.cardName + "! �������� �������� �����: " + targetCard.health);

            if (targetCard.health <= 0)
            {
                targetCard.Die();
            }
        }
    }
}
