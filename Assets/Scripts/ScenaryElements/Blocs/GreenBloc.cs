using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBloc : IBloc
{
    private static Status currentStatus = Status.FREE;
    public override void updatePulseState()
    {

        if (currentStatus == Status.FREE)
        {
            if (gameObject.layer == LayerMask.NameToLayer("foreground"))
            {
                myAnimator.SetBool("Down", true);
                gameObject.layer = LayerMask.NameToLayer("Default");
                initialStatus = changeInitialState(initialStatus);
                GetComponent<SpriteRenderer>().sortingLayerName = "BlocsDown";
                spriteRenderer.material.SetInt("_EnableColor", 0);

            }
            else if (gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                myAnimator.SetBool("Down", false);
                gameObject.layer = LayerMask.NameToLayer("foreground");
                initialStatus = changeInitialState(initialStatus);
                GetComponent<SpriteRenderer>().sortingLayerName = "Blocs";
                spriteRenderer.material.SetInt("_EnableColor", 1);
            }
        }



    }

    public override void ChangeStatusToFree()
    {
        currentStatus = Status.FREE;
    }

    public override void ChangeStatusToBlock()
    {
        currentStatus = Status.BLOCKED;
    }
}
