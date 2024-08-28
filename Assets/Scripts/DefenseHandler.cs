<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseHandler : ActionHandler
{
    protected override void Start()
    {
        base.Start();
        actionValue = 3; // ���� ������
        cooldown = 1f; // �������� ����� ����������
    }

    protected override void OnPerformAction()
    {
        if (playerCard != null)
        {
            playerCard.defense += actionValue; // ��������� ������
            Debug.Log("����� ������� " + actionValue + " ����� ������!");
        }
=======
using UnityEngine;

public class DefenseHandler : MonoBehaviour
{
    public Card playerCard;
    public CardUI playerCardUI;

    public void PlayerDefend()
    {
        if (playerCard.health <= 0)
            return;

        // ��������� ��������� ���� �� �����
        playerCard.defense = 0;
        playerCardUI.UpdateUI();

        // ����� �������� ������ ������
        Debug.Log("Player is defending. Defense is now zero.");
>>>>>>> fbeb6d4c1de2424ef168740aceb83fa5cb352c13
    }
}
