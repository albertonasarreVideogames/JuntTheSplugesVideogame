using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionCheckManager
{
    private List<IConditionCheck> conditionChecks = new List<IConditionCheck>();

    public void AddConditionCheck(IConditionCheck check)
    {
        conditionChecks.Add(check);
    }

    public void ExecuteConditionChecks()
    {
        foreach (var check in conditionChecks)
        {
            check.CheckCondition();
        }
    }
}
