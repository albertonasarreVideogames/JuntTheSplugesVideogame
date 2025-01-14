using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePinchos : Ipinchos
{
    private static Status currentStatus = Status.FREE;
    public override void updatePulseState()
    {

        if (currentStatus == Status.FREE)
        {
            if (gameObject.layer == LayerMask.NameToLayer("lava"))
            {
                myAnimator.SetBool("Down", true);
                spriteRenderer.material.SetFloat("_Power", 0);

                gameObject.layer = LayerMask.NameToLayer("Default");
                initialStatus = changeInitialState(initialStatus);

            }
            else if (gameObject.layer == LayerMask.NameToLayer("Default"))
            {
                myAnimator.SetBool("Down", false);
                spriteRenderer.material.SetFloat("_Power", 10);

                gameObject.layer = LayerMask.NameToLayer("lava");
                initialStatus = changeInitialState(initialStatus);
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
