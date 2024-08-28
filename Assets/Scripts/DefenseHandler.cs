<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseHandler : ActionHandler
{
    protected override void Start()
    {
        base.Start();
        actionValue = 3; // Сила защиты
        cooldown = 1f; // Задержка между действиями
    }

    protected override void OnPerformAction()
    {
        if (playerCard != null)
        {
            playerCard.defense += actionValue; // Добавляем защиту
            Debug.Log("Игрок получил " + actionValue + " очков защиты!");
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

        // Полностью блокируем урон от врага
        playerCard.defense = 0;
        playerCardUI.UpdateUI();

        // Сразу применим эффект защиты
        Debug.Log("Player is defending. Defense is now zero.");
>>>>>>> fbeb6d4c1de2424ef168740aceb83fa5cb352c13
    }
}
