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
                // Comparar solo las distancias en los ejes X y Y
                float distance = Vector2.Distance(
                    new Vector2(players[i].movePointCheker.position.x, players[i].movePointCheker.position.y),
                    new Vector2(players[j].movePointCheker.position.x, players[j].movePointCheker.position.y)
                );
            
                // Si la distancia entre dos jugadores es mayor o igual a 0.05f, no hemos ganado
                if (distance >= 0.05f)
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
