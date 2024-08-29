using UnityEngine;

public class DefenseHandler : ActionHandler
{
    protected override void Start()
    {
        base.Start();
        actionValue = 3; // ���� ������ (��������, 3 ���� ������)
        cooldown = 0f; // ��� ��������
    }

    protected override void OnPerformAction()
    {
        if (playerCard != null)
        {
            playerCard.defense = actionValue; // ������������� ������ �� �������� actionValue
            Debug.Log("����� ������� " + actionValue + " ����� ������!");
        }
    }
}

