using UnityEngine;

public class BossEnemyAttackHandler : BossAttackHandler
{

    private Card lastAttacker; // Последний атакующий

    protected override void Start()
    {
        base.Start();
        actionValue = 8; // Убедитесь, что это значение корректно
        cooldown = 1f; // Время перезарядки
    }

    public void SetLastAttacker(Card attacker)
    {
        lastAttacker = attacker;
    }

    protected override void OnPerformAction()
    {
        if (targetCard == null || activeCard == null)
        {
            Debug.LogError("Target card or active card is not set.");
            return;
        }

        // Используем последний атакующий
        if (lastAttacker != null)
        {
            int damage = Mathf.Max(0, actionValue - lastAttacker.defense);
            targetCard.health -= damage; // Наносим урон врагу
            Debug.Log(activeCard.cardName + " нанес " + damage + " урона " + targetCard.cardName + "! Осталось здоровья врага: " + targetCard.health);

            if (targetCard.health <= 0)
            {
                targetCard.Die();
            }
        }
        else
        {
            Debug.LogError("Last attacker is not set.");
        }
    }
}
