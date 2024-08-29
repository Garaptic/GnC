using UnityEngine;

public class DefenseHandler : ActionHandler
{
    protected override void Start()
    {
        base.Start();
        actionValue = 3; // Сила защиты (например, 3 очка защиты)
        cooldown = 0f; // Без задержки
    }

    protected override void OnPerformAction()
    {
        if (playerCard != null)
        {
            playerCard.defense = actionValue; // Устанавливаем защиту на значение actionValue
            Debug.Log("Игрок получил " + actionValue + " очков защиты!");
        }
    }
}

