using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ipinchos : MonoBehaviour, ISwitchKeeperObjetiveElement, ISwitcPulseObjetiveElement
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
            //myAnimator.SetBool("Down", initialStatus == InitialStatus.DOWN);
            spriteRenderer.material.SetFloat("_Power", initialStatus == InitialStatus.DOWN ? 0 : 10);

            gameObject.layer = LayerMask.NameToLayer(initialStatus == InitialStatus.DOWN ? "Default" : "lava");
        }
        else
        {
            //myAnimator.SetBool("Down", initialStatus != InitialStatus.DOWN);
            spriteRenderer.material.SetFloat("_Power", initialStatus == InitialStatus.DOWN ? 10 : 0);

            gameObject.layer = LayerMask.NameToLayer(initialStatus != InitialStatus.DOWN ? "Default" : "lava");
        }
    }

    public void updateSwitchLevelStatusOfPlayers(Player[] players, Enemy[] enemies)
    {
        
    }

    public virtual void updatePulseState() { }

    public virtual void ChangeStatusToFree() { }

    public virtual void ChangeStatusToBlock() { }

    public virtual void SetShaderColor() {

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material = new Material(spriteRenderer.material);

        spriteRenderer.material.SetFloat("_RandomSeed", transform.position.x * 100f);
        spriteRenderer.material.SetFloat("_RandomSeed2", transform.position.y * 100f);

        if (initialStatus == InitialStatus.DOWN) { spriteRenderer.material.SetFloat("_Power", 0); }

    }

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
