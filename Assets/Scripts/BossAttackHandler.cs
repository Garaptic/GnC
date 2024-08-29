using UnityEngine;

public class BossAttackHandler : BossActionHandler
{
    public Card targetCard; // Целевая карта
    public Card activeCard; // Активная карта

    protected override void Start()
    {
        base.Start();
        actionValue = 3; // Примерная сила атаки
        cooldown = 1f; // Время перезарядки
    }

    protected override void OnPerformAction()
    {
        if (targetCard == null || enemyCard == null)
        {
            Debug.LogError("Target card or enemy card is not set.");
            return;
        }

        if (targetCard.health > 0)
        {
            int damage = Mathf.Max(0, actionValue - targetCard.defense);
            enemyCard.health -= damage;
            Debug.Log(targetCard.cardName + " нанес " + damage + " урона врагу! Осталось здоровья врага: " + enemyCard.health);

            if (enemyCard.health <= 0)
            {
                enemyCard.Die();
            }
        }
    }
}
