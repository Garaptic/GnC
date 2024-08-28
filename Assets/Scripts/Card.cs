using UnityEngine;

public class Card : MonoBehaviour
{
    public string cardName;
    [SerializeField] public int health;
    [SerializeField] public int strength;
    [SerializeField] public int defense;
    [SerializeField] public int defaultDefense;

    public void Attack(Card target)
    {
        if (target.defense > 0)
        {
            target.defense -= strength;
            if (target.defense < 0)
            {
                target.health += target.defense;
                target.defense = 0;
            }
        }
        else
        {
            target.health -= strength;
        }

        if (target.health <= 0)
        {
            target.Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        Debug.Log(cardName + " повержен!");
    }
}
