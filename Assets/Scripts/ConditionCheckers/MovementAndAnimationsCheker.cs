using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAndAnimationsCheker : IConditionCheck
{

    private Player[] players;
    private Enemy[] enemies;

    public MovementAndAnimationsCheker(Player[] players, Enemy[] enemies)
    {
        this.players = players;
        this.enemies = enemies;
    }

    public void CheckCondition()
    {
        if (GameManager.Instance.State == GameState.Lose) { PlayerAnimation.SetAnimationForAllPlayers(AnimationHandler.AnimationState.Dying, player => player.NextAnimationTrigger != AnimationHandler.AnimationState.DieOnHole); }

        //if (GameManager.Instance.State == GameState.Gaming) { GameManager.Instance.UpdateGameState(GameState.Procesing); }

        SoundManager.cleanSoundToBuffer();

        for (int i = 0; i < players.Length; i++)
        {
            // can put animation death here?
            // create animation geston on player object, the win lose and another states save the next animations steps, and here it will be checked and activated
            
            players[i].GetComponent<PlayerAnimation>().executetriggeranimations(); // TODO THE ORDER OF THIS TWO FUNCTIONS ALTERATES THE ANIMATION ON TESTS
            players[i].GetComponent<Player>().updateMovePoint();
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().updateMovePoint();
            enemies[i].GetComponent<EnemyAnimation>().executetriggeranimations();
        }

        MonoBehaviourSingleton.Instance.StartCoroutine(ManageEnemiesOnSamePlaceAfterMovement());
        SoundManager.PlayAllSoundsAndClear();

    }

    IEnumerator ManageEnemiesOnSamePlaceAfterMovement()
    {
        while (!AllEnemiesNotMoving())
        {
            yield return null; // Espera un frame
        }

        for (int j = 0; j < enemies.Length; j++)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<Enemy>().ManageEnemiesOnSamePlace();

            }
            while (!AllEnemiesNotMoving())
            {
                yield return null; // Espera un frame
            }
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().updatecheckMovePoint();
        }

        // Aqui hay un patron, tengo que volver a detectar las colisiones despues de que los enemigos se reorganicen.Cuando los pinchos tambien afecten al enemigo, tendre que modificarlo aqui tambien, por eso no es correcto que esto tenga mas una responsabilidad.Habria que aplicar SOLID para mejorar esto.
        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy enemy = enemies[i];
            enemy.ChangeFloorLevel(Player.PlayerFloorLevel.Down);
            if (enemy.CkeckLayerContact("foreground")) { enemy.ChangeFloorLevel(Player.PlayerFloorLevel.Up); } else { enemy.ChangeFloorLevel(Player.PlayerFloorLevel.Down); }
        }

        if (CheckEnemyPlayerCollision())
        {
            GameManager.Instance.UpdateGameState(GameState.Lose);
        }

        //if (GameManager.Instance.State == GameState.Procesing) { GameManager.Instance.UpdateGameState(GameState.Gaming); }
    }

    private static bool enemyisNOTmovig(Enemy enemy)
    {
        return enemy.checkIfPlayerIsNOTStrillMoveent();
    }

    private bool AllEnemiesNotMoving()
    {
        return Array.TrueForAll(enemies, enemyisNOTmovig);
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
                    if (player.getnextAnimation() != AnimationHandler.AnimationState.Dying)
                    {
                        player.ExecuteAnimation("Death");
                        player.setnextAnimation(AnimationHandler.AnimationState.Dying);// esto es cuando los enemigos se reorganizan
                    }

                    if (enemy.getnextAnimation() != AnimationHandler.AnimationState.Attacking)
                    {
                        enemy.ExecuteAnimation("Attack");
                        enemy.setnextAnimation(AnimationHandler.AnimationState.Attacking);// esto es cuando los enemigos se reorganizan
                    }

                    returned = true;
                }
            }
        }

        return returned;
    }
}
