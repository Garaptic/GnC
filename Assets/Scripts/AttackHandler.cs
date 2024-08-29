using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : ActionHandler
{
    public Card targetCard; // ������� �����

    protected override void Start()
    {
        base.Start();
        actionValue = 3; // ���� �����
        cooldown = 1f; // ����� �����������
        Debug.Log("AttackHandler Start: targetCard = " + (targetCard ? targetCard.name : "null"));
    }

    protected override void OnPerformAction()
    {
        if (targetCard != null && targetCard.health > 0)
        {
            // ���� � ���� ���� ������
            if (targetCard.defense > 0)
            {
                // ��������� ������ � ������� ���������� ����
                int damage = Mathf.Max(0, actionValue - targetCard.defense);
                targetCard.health -= damage;
                Debug.Log("Attack dealt " + damage + " damage! Target health: " + targetCard.health);
                targetCard.defense = Mathf.Max(0, targetCard.defense - actionValue); // ��������� ������ �� �������� �����
            }
            else
            {
                // ������� ���� ��� ����� ������
                targetCard.health -= actionValue;
                Debug.Log("Attack dealt " + actionValue + " damage! Target health: " + targetCard.health);
            }
        }
    }
}