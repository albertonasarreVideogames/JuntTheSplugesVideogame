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
    protected SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (initialStatus == InitialStatus.DOWN)
        {
            myAnimator.SetBool("Down", true);
            spriteRenderer.material.SetInt("_EnableColor", 0);
            gameObject.layer = LayerMask.NameToLayer("Default");
        }
        UpdateSortingOrder();
    }

    public void updateSwitchKeepeState(bool setLikeoriginal)
    {
        if (setLikeoriginal)
        {
            myAnimator.SetBool("Down", initialStatus == InitialStatus.DOWN);
            gameObject.layer = LayerMask.NameToLayer(initialStatus == InitialStatus.DOWN ? "Default" : "foreground");
            GetComponent<SpriteRenderer>().sortingLayerName = initialStatus == InitialStatus.DOWN ? "BlocsDown" : "Blocs";
            spriteRenderer.material.SetInt("_EnableColor", initialStatus == InitialStatus.DOWN ? 0 : 1); // Pensar si mantener esto lo hace mejor, ya que el azul te indica que es temporal
        }
        else
        {
            myAnimator.SetBool("Down", initialStatus != InitialStatus.DOWN);
            gameObject.layer = LayerMask.NameToLayer(initialStatus != InitialStatus.DOWN ? "Default" : "foreground");
            GetComponent<SpriteRenderer>().sortingLayerName = initialStatus != InitialStatus.DOWN ? "BlocsDown" : "Blocs";
            spriteRenderer.material.SetInt("_EnableColor", initialStatus != InitialStatus.DOWN ? 0 : 1); // Pensar si mantener esto lo hace mejor, ya que el azul te indica que es temporal
        }
    }

    public void updateSwitchLevelStatusOfPlayers(Player[] players, Enemy[] enemies)
    {

        for (int i = 0; i < players.Length; i++)
        {
            // Update the vertical level of the player;
            Player player = players[i];
            player.ChangeFloorLevel(Player.PlayerFloorLevel.Down);
            if (player.playerType == Player.PlayerType.Type1) { player.GetComponent<SpriteRenderer>().sortingLayerName = "playerBehindBlocs"; }
            if (player.playerType == Player.PlayerType.Type2) { player.GetComponent<SpriteRenderer>().sortingLayerName = "playerBehind2Blocs"; }
            if (player.playerType == Player.PlayerType.Type3) { player.GetComponent<SpriteRenderer>().sortingLayerName = "playerBehind3Blocs"; }
            if (player.CkeckLayerContact("foreground")) {
                player.ChangeFloorLevel(Player.PlayerFloorLevel.Up);
                if (player.playerType == Player.PlayerType.Type1) { player.GetComponent<SpriteRenderer>().sortingLayerName = "player"; }
                if (player.playerType == Player.PlayerType.Type2) { player.GetComponent<SpriteRenderer>().sortingLayerName = "player2"; }
                if (player.playerType == Player.PlayerType.Type3) { player.GetComponent<SpriteRenderer>().sortingLayerName = "player3"; }
            }
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

    private void UpdateSortingOrder()
    {
        // Invertimos el valor de Y para que el más bajo esté encima.
        spriteRenderer.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
    }
}
