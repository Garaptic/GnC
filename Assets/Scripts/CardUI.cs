using UnityEngine;
using TMPro; // TextMeshPro

public class CardUI : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI defenseText;

    private Card card;

    public void SetCard(Card newCard)
    {
        card = newCard;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (card != null)
        {
            if (nameText != null)
                nameText.text = card.cardName;
            if (healthText != null)
                healthText.text = "Health: " + card.health;
            if (strengthText != null)
                strengthText.text = "Strength: " + card.strength;
            if (defenseText != null)
                defenseText.text = "Defense: " + card.defense;
        }
    }
}
