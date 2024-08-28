using UnityEngine;
using TMPro;

public class CardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text cardNameText;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text strengthText;
    [SerializeField] private TMP_Text defenseText;

    public void UpdateUI(Card card)
    {
        cardNameText.text = card.cardName;
        healthText.text = "Health: " + card.health;
        strengthText.text = "Strength: " + card.strength;
        defenseText.text = "Defense: " + card.defense;
    }
}
