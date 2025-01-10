using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionCheck : IConditionCheck
{

    private Player[] players;

    public WinConditionCheck(Player[] players)
    {
        this.players = players;
    }
    public void CheckCondition()
    {
        bool Win = true;
        for (int i = 0; i < players.Length - 1; i++)
        {
            for (int j = i + 1; j < players.Length; j++)
            {
                if (Vector3.Distance(players[i].movePointCheker.position, players[j].movePointCheker.position) >= .05f)
                {
                    Win = false;
                }
            }
        }
        if (Win)
        {
            GameManager.Instance.UpdateGameState(GameState.Victory);
        }
    }
}
