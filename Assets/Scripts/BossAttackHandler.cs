using UnityEngine;

public class BossAttackHandler : BossActionHandler
{
    public Card targetCard; // Целевая карта (враг)
    public Card activeCard; // Активная карта (игрок)

    protected override void Start()
    {
        base.Start();
        cooldown = 1f; // Время перезарядки
    }

    protected override void OnPerformAction()
    {
        if (targetCard == null || activeCard == null)
        {
            Debug.LogError("Target card or active card is not set.");
            return;
        }

        if (targetCard.health > 0)
        {
            int damage = Mathf.Max(0, actionValue - targetCard.defense);
            targetCard.health -= damage; // Наносим урон врагу
            Debug.Log(activeCard.cardName + " нанес " + damage + " урона " + targetCard.cardName + "! Осталось здоровья врага: " + targetCard.health);

            if (targetCard.health <= 0)
            {
                targetCard.Die();
            }
        }
    }
}
