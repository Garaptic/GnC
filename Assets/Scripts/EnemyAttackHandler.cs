using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHandler : AttackHandler
{
    protected override void Start()
    {
        base.Start();
        actionValue = 4; // например, сила атаки врага
        cooldown = 1f; // задержка между атаками врага
    }

    protected override void OnPerformAction()
    {
        // Реализация атаки врага
        if (targetCard != null && targetCard.health > 0)
        {
            int damage = Mathf.Max(0, actionValue - targetCard.defense);
            targetCard.health -= damage;
            Debug.Log("Враг нанес " + damage + " урона! Осталось здоровья: " + targetCard.health);
        }
    }
}
