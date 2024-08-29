using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : ActionHandler
{
    public Card targetCard; // Целевая карта

    protected override void Start()
    {
        base.Start();
        actionValue = 3; // Сила атаки
        cooldown = 1f; // Время перезарядки
        Debug.Log("AttackHandler Start: targetCard = " + (targetCard ? targetCard.name : "null"));
    }

    protected override void OnPerformAction()
    {
        if (targetCard != null && targetCard.health > 0)
        {
            // Если у цели есть защита
            if (targetCard.defense > 0)
            {
                // Уменьшаем защиту и наносим оставшийся урон
                int damage = Mathf.Max(0, actionValue - targetCard.defense);
                targetCard.health -= damage;
                Debug.Log("Attack dealt " + damage + " damage! Target health: " + targetCard.health);
                targetCard.defense = Mathf.Max(0, targetCard.defense - actionValue); // Уменьшаем защиту на величину атаки
            }
            else
            {
                // Наносим урон без учета защиты
                targetCard.health -= actionValue;
                Debug.Log("Attack dealt " + actionValue + " damage! Target health: " + targetCard.health);
            }
        }
    }
}