using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwitchKeeperObjetiveElement 
{
    void updateSwitchKeepeState(bool setLikeoriginal);
    void updateSwitchLevelStatusOfPlayers(Player[] players, Enemy[] enemies);
}
