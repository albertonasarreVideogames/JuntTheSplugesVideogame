using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : Player
{
   

    public bool checkNextmovementIsPossible(Vector2 Generalmovement)
    {
        if (currentPlayerFloorLevel == PlayerFloorLevel.Down)
        {
            if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Generalmovement.x, Generalmovement.y, 0f), .2f, whatstopMovmeet))
            {
                return true;
            }
        }
        else if (currentPlayerFloorLevel == PlayerFloorLevel.Up)
        {

            if (Physics2D.OverlapCircle(movePoint.position + new Vector3(Generalmovement.x, Generalmovement.y, 0f), .2f, whatstopMovmeet))
            {
                return true;
            }

        }

        return false;
    }

    public override IEnumerator updateMovepointChecker(Vector2 Generalmovement)
    {
            movePointCheker.position += new Vector3(Generalmovement.x, Generalmovement.y, 0f);

        yield return new WaitForSeconds(1f);
    }



}
