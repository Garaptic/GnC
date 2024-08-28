using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionHandler : MonoBehaviour
{
    public CardUI playerCardUI;
    public CardUI enemyCardUI;

    public Card playerCard;
    public Card enemyCard;

    public int actionValue;
    public float cooldown = 0;
    protected float timer = 0;

    protected virtual void Start()
    {
        timer = cooldown;
    }

    protected virtual void Update()
    {
        timer += Time.deltaTime;
    }

    public virtual void PerformAction()
    {
        if (timer > cooldown)
        {
            OnPerformAction();
            timer = 0;
            UpdateUI();
        }
    }

    protected virtual void OnPerformAction()
    {
        // Реализация в дочерних классах
    }

    protected virtual void UpdateUI()
    {
        if (playerCardUI != null && playerCard != null)
            playerCardUI.UpdateUI(playerCard);

        if (enemyCardUI != null && enemyCard != null)
            enemyCardUI.UpdateUI(enemyCard);
    }
}
