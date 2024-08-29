using UnityEngine;

public class BossAttackHandler : BossActionHandler
{
    public Card targetCard; // Целевая карта

    protected override void Start()
    {
        base.Start();
        actionValue = 3; // Примерная сила атаки
        cooldown = 1f; // Время перезарядки
    }

    protected override void OnPerformAction()
    {
        if (targetCard != null && targetCard.health > 0)
        {
            int damage = Mathf.Max(0, actionValue - targetCard.defense);
            targetCard.health -= damage;
            Debug.Log(firstCard.cardName + " нанес " + damage + " урона врагу! Осталось здоровья врага: " + enemyCard.health);

            if (targetCard.health <= 0)
            {
                targetCard.Die();
            }
        }
    }

    protected override void UpdateUI()
    {
        base.UpdateUI(); // Обновляем UI текущей карты
    }
}