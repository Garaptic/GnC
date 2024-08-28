using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHandler : AttackHandler
{
    protected override void Start()
    {
        base.Start();
        actionValue = 4; // ��������, ���� ����� �����
        cooldown = 1f; // �������� ����� ������� �����
    }

    protected override void OnPerformAction()
    {
        // ���������� ����� �����
        if (targetCard != null && targetCard.health > 0)
        {
            int damage = Mathf.Max(0, actionValue - targetCard.defense);
            targetCard.health -= damage;
            Debug.Log("���� ����� " + damage + " �����! �������� ��������: " + targetCard.health);
        }
    }
}
