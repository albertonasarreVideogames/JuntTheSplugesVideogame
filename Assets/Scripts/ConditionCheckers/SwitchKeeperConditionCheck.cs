using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SwitchKeeperConditionCheck : IConditionCheck
{

    private Player[] players;
    private ISwitchKeeperObjetiveElement[] elements;
    private string switchLayerName;
    private Enemy[] enemies;

    public SwitchKeeperConditionCheck(Player[] players, ISwitchKeeperObjetiveElement[] elements, Enemy[] enemies, string switchLayerName)
    {
        this.players = players;
        this.elements = elements;
        this.enemies = enemies;
        this.switchLayerName = switchLayerName;
    }
    public void CheckCondition()
    {
        
        if (CheckPlayersCollisionwithSwitch())
        {
            updateSwitchKeep(false);
            SwitchManager.TriggerAnimation(switchLayerName, "pulsed", true);
        }
        else
        {
            updateSwitchKeep(true);
            SwitchManager.TriggerAnimation(switchLayerName, "pulsed", false);
        }

        if (elements.Length > 0) { elements[0].updateSwitchLevelStatusOfPlayers(players, enemies); }
    }

    private void updateSwitchKeep(bool active)
    {
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].updateSwitchKeepeState(active);
        }
    }

    private bool playersAllswitchContact(Player player)
    {
        return player.CheckSwitchContactAndSetAnimation(switchLayerName); 
    }

    private bool CheckPlayersCollisionwithSwitch()
    {

        bool anyOnSwitch = false;

        foreach (var player in players)
        {
            if (playersAllswitchContact(player))
            {
                anyOnSwitch = true;
            }
        }

        return anyOnSwitch;

    }
}
