using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void EnemyKilled()
    {
        if (goalType == GoalType.Kill)
        {
            currentAmount += 1;
        }
    }

    public void ItemCollected()
    {
        if (goalType == GoalType.Gathering)
        {
            currentAmount += 1;
        }
    }

    public void Delivery ()
    {
        if (goalType == GoalType.Delivery)
        {
            currentAmount += 1;
        }
    }
}

public enum GoalType
{
    Kill,
    Gathering,
    Delivery
}
