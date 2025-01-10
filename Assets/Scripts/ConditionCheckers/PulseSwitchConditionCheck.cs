using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseSwitchConditionCheck : IConditionCheck
{
    private Player[] players;
    private ISwitcPulseObjetiveElement[] elements;
    private Enemy[] enemies;
    string SwitchLayerName;

    public PulseSwitchConditionCheck(Player[] players, ISwitcPulseObjetiveElement[] elements, Enemy[] enemies, string SwitchLayerName)
    {
        this.players = players;
        this.elements = elements;
        this.enemies = enemies;
        this.SwitchLayerName = SwitchLayerName;

    }
    public void CheckCondition()
    {
        if (CheckPlayersCollisionwithSwitch())
        {
            updateSwitcPulse();
            if (elements.Length > 0) { elements[0].ChangeStatusToBlock(); }

            if (elements.Length > 0) { elements[0].updateSwitchLevelStatusOfPlayers(players, enemies); }
            SwitchManager.TriggerAnimation(SwitchLayerName, "pulsed", true);
        }
        else
        {
            if (elements.Length > 0) { elements[0].ChangeStatusToFree(); }
            SwitchManager.TriggerAnimation(SwitchLayerName, "pulsed", false);
        }
    }

    private void updateSwitcPulse()
    {
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i].updatePulseState();
        }
    }

    private bool playersAllBlueswitchContact(Player player)
    {
        return player.CheckSwitchContactAndSetAnimation(this.SwitchLayerName);
    }

    private bool CheckPlayersCollisionwithSwitch()
    {

        bool anyOnSwitch = false;

        foreach (var player in players)
        {
            if (playersAllBlueswitchContact(player))
            {
                anyOnSwitch = true;
            }
        }

        return anyOnSwitch;

    }


}
