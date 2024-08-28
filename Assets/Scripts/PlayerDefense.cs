using UnityEngine;

public class PlayerDefense : MonoBehaviour
{
    public Card playerCard;

    public void RestoreDefense()
    {
        if (playerCard.defense < playerCard.defaultDefense)
        {
            playerCard.defense += 1; // Восстановление защиты на 1
            Debug.Log("Player's defense restored by 1.");
        }
    }
}
