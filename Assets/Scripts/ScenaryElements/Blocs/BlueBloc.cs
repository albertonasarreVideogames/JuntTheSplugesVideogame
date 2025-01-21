using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBloc : IBloc
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

            }
            else if (gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                myAnimator.SetBool("Down", false);
                gameObject.layer = LayerMask.NameToLayer("foreground");
                initialStatus = changeInitialState(initialStatus);
                GetComponent<SpriteRenderer>().sortingLayerName = "Blocs";
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
