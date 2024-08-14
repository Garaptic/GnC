using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    public Card playerCard;
    public Card enemyCard;
    public CardUI enemyCardUI;
    public CardUI playerCardUI;

    public void PlayerAttack()
    {
        if (playerCard.health <= 0 || enemyCard.health <= 0)
            return;

        // Игнорируем защиту врага при атаке
        int damage = Mathf.Max(0, playerCard.strength);
        enemyCard.health -= damage;
        enemyCardUI.UpdateUI();

        if (enemyCard.health <= 0)
        {
            CheckFightEnd();
            return;
        }

        // Враг атакует, если враг все еще жив
        EnemyTurn();
    }

    void EnemyTurn()
    {
        if (playerCard.health <= 0 || enemyCard.health <= 0)
            return;

        // Наносим урон игроку с учётом защиты врага
        int damage = Mathf.Max(0, enemyCard.strength - playerCard.defense);
        playerCard.health -= damage;
        playerCardUI.UpdateUI();

        CheckFightEnd();
    }

    void CheckFightEnd()
    {
        if (playerCard.health <= 0)
        {
            Debug.Log("Player lost!");
        }
        else if (enemyCard.health <= 0)
        {
            Debug.Log("Player won!");
        }
    }
}
