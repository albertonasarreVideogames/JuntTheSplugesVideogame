using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LoseConditionCheck : IConditionCheck
{
    private Player[] players;
    private Enemy[] enemies;

    public LoseConditionCheck(Player[] players, Enemy[] enemies)
    {
        this.players = players;
        this.enemies = enemies;
    }
    public void CheckCondition()
    {
        if (CheckPlayersCollisionwithLava())
        {
            GameManager.Instance.UpdateGameState(GameState.Lose);
        }

        if (CheckEnemyPlayerCollision())
        {
            GameManager.Instance.UpdateGameState(GameState.Lose);
        }
    }

    private static bool checkDamage(Player player)
    {
        return player.CheckSwitchContactAndSetAnimation("lava");
    }

    private bool CheckPlayersCollisionwithLava(){

        bool anyDamaged = false;

        foreach (var player in players)
        {
            if (checkDamage(player))
            {
                anyDamaged = true;
            }
        }

        return anyDamaged;

    }

    private bool CheckEnemyPlayerCollision()
    {
        bool returned = false;
        foreach (Enemy enemy in enemies)
        {
            foreach (Player player in players)
            {
                if (enemy.movePointCheker.position == player.movePointCheker.position)
                {
                    player.setnextAnimation(AnimationHandler.AnimationState.Dying);
                    player.ExecuteAnimation("Death");

                    enemy.setnextAnimation(AnimationHandler.AnimationState.Attacking);
                    enemy.ExecuteAnimation("Attack");

                    returned = true;
                }
            }
        }
        foreach (Enemy enemy in enemies)
        {
            foreach (Player player in players)
            {
                if (enemy.movePointCheker.position == player.transform.position && enemy.transform.position == player.movePointCheker.position)
                {
                    player.setnextAnimation(AnimationHandler.AnimationState.Dying);
                    player.ExecuteAnimation("Death");
                    enemy.setnextAnimation(AnimationHandler.AnimationState.Attacking);
                    enemy.ExecuteAnimation("Attack");

                    returned = true;
                }
            }
        }
        return returned;
    }
}
