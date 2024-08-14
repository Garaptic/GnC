using UnityEngine;

public class DefenseHandler : MonoBehaviour
{
    public Card playerCard;
    public CardUI playerCardUI;

    public void PlayerDefend()
    {
        if (playerCard.health <= 0)
            return;

        // Полностью блокируем урон от врага
        playerCard.defense = 0;
        playerCardUI.UpdateUI();

        // Сразу применим эффект защиты
        Debug.Log("Player is defending. Defense is now zero.");
    }
}
