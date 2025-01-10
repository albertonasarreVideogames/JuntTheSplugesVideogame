using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwitcPulseObjetiveElement
{
    void updatePulseState();

    void ChangeStatusToFree();

    void ChangeStatusToBlock();

    void updateSwitchLevelStatusOfPlayers(Player[] players, Enemy[] enemies);
}

