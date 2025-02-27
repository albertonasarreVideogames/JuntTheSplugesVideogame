using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerSelected
{

    public CheckPlayerSelected()
    {
        
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Player.changePlayerTypeToMove();
            GamingState.PlayerMovementsStored.AddMChangePlayer(1);
        }
    }

}
