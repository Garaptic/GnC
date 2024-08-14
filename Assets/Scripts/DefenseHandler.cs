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
    }
}
