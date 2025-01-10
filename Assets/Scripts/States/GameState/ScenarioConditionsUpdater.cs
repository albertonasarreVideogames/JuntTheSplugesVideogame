using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioConditionsUpdater
{
    private ConditionCheckManager conditionCheckManager = new ConditionCheckManager();

    public ScenarioConditionsUpdater(Player[] players, Enemy[] enemies, ISwitchKeeperObjetiveElement[][] KeeperElements, ISwitcPulseObjetiveElement[][] pulseElements, Dictionary<Type, string> switchTypeMap)
    {
        // Orden muy importante
        conditionCheckManager.AddConditionCheck(new WinConditionCheck(players));

        // Agregar condiciones específicas para cada tipo de elemento del interruptor
        addSwitches(players, enemies, KeeperElements, pulseElements, switchTypeMap);

        conditionCheckManager.AddConditionCheck(new LoseConditionCheck(players, enemies));
        conditionCheckManager.AddConditionCheck(new MovementAndAnimationsCheker(players, enemies));
    }

    public void execute()
    {
        conditionCheckManager.ExecuteConditionChecks();
    }

    private void addSwitches(Player[] players, Enemy[] enemies, ISwitchKeeperObjetiveElement[][] KeeperElements, ISwitcPulseObjetiveElement[][] pulseElements, Dictionary<Type, string> switchTypeMap)
    {

        foreach (var elements in KeeperElements)
        {
            if (elements.Length > 0)
            {
                string switchType;
                if (switchTypeMap.TryGetValue(elements[0].GetType(), out switchType))
                    if (switchType != null)
                    {
                        conditionCheckManager.AddConditionCheck(new SwitchKeeperConditionCheck(players, elements, enemies, switchType));
                    }
            }

        }
        foreach (var elements in pulseElements)
        {
            if (elements.Length > 0)
            {
                string switchType;
                if (switchTypeMap.TryGetValue(elements[0].GetType(), out switchType))
                    if (switchType != null)
                    {
                        conditionCheckManager.AddConditionCheck(new PulseSwitchConditionCheck(players, elements, enemies, switchType + "Pulse"));
                    }
            }

        }
    }
}
