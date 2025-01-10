using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IBloc : MonoBehaviour, ISwitchKeeperObjetiveElement , ISwitcPulseObjetiveElement
{
     public enum Status
    {
        BLOCKED,
        FREE,
    }

    public enum InitialStatus
    {
        UP,
        DOWN,
    }

    public InitialStatus initialStatus;

    protected Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        if (initialStatus == InitialStatus.DOWN)
        {
            myAnimator.SetBool("Down", true);
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }

    public void updateSwitchKeepeState(bool setLikeoriginal)
    {
        if (setLikeoriginal)
        {
            myAnimator.SetBool("Down", initialStatus == InitialStatus.DOWN);
            gameObject.layer = LayerMask.NameToLayer(initialStatus == InitialStatus.DOWN ? "Default" : "foreground");
        }
        else
        {
            myAnimator.SetBool("Down", initialStatus != InitialStatus.DOWN);
            gameObject.layer = LayerMask.NameToLayer(initialStatus != InitialStatus.DOWN ? "Default" : "foreground");
        }
    }

    public void updateSwitchLevelStatusOfPlayers(Player[] players, Enemy[] enemies)
    {

        for (int i = 0; i < players.Length; i++)
        {
            // Update the vertical level of the player;
            Player player = players[i];
            player.ChangeFloorLevel(Player.PlayerFloorLevel.Down);
            if (player.CkeckLayerContact("foreground")) { player.ChangeFloorLevel(Player.PlayerFloorLevel.Up); }
        }
        for (int i = 0; i < enemies.Length; i++)
        {
            // Update the vertical level of the player;
            Enemy enemy = enemies[i];
            enemy.ChangeFloorLevel(Player.PlayerFloorLevel.Down);
            if (enemy.CkeckLayerContact("foreground")) { enemy.ChangeFloorLevel(Player.PlayerFloorLevel.Up); }
        }

    }


    public virtual void updatePulseState(){}

    public virtual void ChangeStatusToFree(){}

    public virtual void ChangeStatusToBlock(){}

    protected InitialStatus changeInitialState(InitialStatus estadoActual)
    {
        if (estadoActual == InitialStatus.UP)
        {
            return InitialStatus.DOWN;
        }
        else
        {
            return InitialStatus.UP;
        }
    }
}
