using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagePlayersMovement
{
    private Player[] players;

    private MainPlayer[] mainplayers;

    private Enemy[] enemies;

    private readonly Action checkScenaryConditions;

    private Vector2 movement;
    // Start is called before the first frame update
    public ManagePlayersMovement(Player[] players, MainPlayer[] mainPlayers, Enemy[] enemies, Action checkScenaryConditions)
    {
        this.players = players;
        this.mainplayers = mainPlayers;
        this.enemies = enemies;
        this.checkScenaryConditions = checkScenaryConditions;
    }

    public void Execute()
    {

        CheckplayersMove();

    }

    private void CheckplayersMove()
    {
        //Get imputs
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        managePlayersMovement(movement);
    }

    private void movePlayers(Vector2 movement)
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<Player>().updateMovepointChecker(movement); 
        }
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<Player>().checkCollisions();
        }

        for (int i = 0; i < enemies.Length; i++)
        {
            for (int j = 0; j < enemies.Length; j++)
            {
                enemies[j].GetComponent<Enemy>().ManageEnemieMovementIfAnotherEnemyMoveOnSameDirectionAndPlaceInfrontHim();
            }
        }

        if (GameManager.Instance.State == GameState.Gaming) { GamingState.PlayerMovementsStored.addMovement(movement); }

    }

    private void managePlayersMovement(Vector2 movement)
    {
        //avoid diagon movement
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            movement.y = 0;
        }
        else
        {
            movement.x = 0;
        }

        //check if key is presed
        if (Mathf.Abs(movement.x) == 1f || Mathf.Abs(movement.y) == 1f)
        {
            //chek if players are still movement
            if (checkAnyPlayerIsmoving())
            {
                //check the movement of the mainplayers
                if (Array.TrueForAll(mainplayers, mainplayer => MainPlayerscanmove(mainplayer, movement)))
                {
                    movePlayers(movement);
                    checkScenaryConditions?.Invoke();
                }
            }
        }

    }

    //Functions to check conditions
    public bool checkAnyPlayerIsmoving()
    {
        //Debug.Log(Array.TrueForAll(players, playerisNOTmovig));
        return Array.TrueForAll(players, playerisNOTmovig);
    }
    private static bool playerisNOTmovig(Player player)
    {
        return player.checkIfPlayerIsNOTStrillMoveent();
    }

    private static bool MainPlayerscanmove(MainPlayer player, Vector2 Generalmovement)
    {
        return player.checkNextmovementIsPossible(Generalmovement);
    }

    //TESTING
    public void Simulatemovement(Vector2 movement)
    {
        managePlayersMovement(movement);
    }

    public void movePlayersWithLastMovementStored()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<Player>().updateMovepointCheckerToRewind();
        }

        checkScenaryConditions?.Invoke();

    }

}
