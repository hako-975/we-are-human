using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;
    public bool ask = false;

    public bool IsReached()
    {
        if (goalType == GoalType.Kill || goalType == GoalType.Gathering)
        {
            return (currentAmount >= requiredAmount);
        }

        if (goalType == GoalType.Delivery)
        {
            if (ask == true)
            {
                return true;
            }
        }

        return false;
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
            ask = true;
        }
    }
}

public enum GoalType
{
    Kill,
    Gathering,
    Delivery
}
