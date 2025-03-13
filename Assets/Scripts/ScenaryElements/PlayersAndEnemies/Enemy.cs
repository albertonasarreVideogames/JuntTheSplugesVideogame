using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Player
{
    public enum EnemyMovement
    {
        Normal,
        Reverse,
        ReverseVertical,
        ReverseHorizontal
    }

    public EnemyMovement enemyMovement;
    private Vector3 offset;
    public bool test;

    public override void updateMovepointChecker(Vector2 Generalmovement)
    {

        offset = new Vector3(Generalmovement.x, Generalmovement.y, 0f);

        if (enemyMovement == EnemyMovement.Reverse) { offset = -new Vector3(Generalmovement.x, Generalmovement.y, 0f); }
        if (enemyMovement == EnemyMovement.ReverseVertical) { offset = new Vector3(Generalmovement.x, -Generalmovement.y, 0f); }
        if (enemyMovement == EnemyMovement.ReverseHorizontal) { offset = new Vector3(-Generalmovement.x, Generalmovement.y, 0f); }

        playerAnimation.SetNextAnimationTrigger(AnimationHandler.AnimationState.Running);

        movePointCheker.position += offset;

        if (enemyMovement != EnemyMovement.Reverse) // Solo hacer flip si no es Reverse
        {
            if (Generalmovement.x > 0 && !facingRight)
            {
                flip();  // El flip hace que el personaje se voltee a la derecha
            }
            else if (Generalmovement.x < 0 && facingRight)
            {
                flip();  // El flip hace que el personaje se voltee a la izquierda
            }
        }
        else // Si el movimiento es Reverse, invertimos la lógica del flip
        {
            if (Generalmovement.x < 0 && !facingRight) // Si se mueve a la izquierda, voltea
            {
                flip();
            }
            else if (Generalmovement.x > 0 && facingRight) // Si se mueve a la derecha, voltea
            {
                flip();
            }
        }
    }

    public override void updateMovepointCheckerToRewind()
    {
        Vector2 Generalmovement = PlayerMovementsStored.getButtonOnLastPosition();
        offset = new Vector3(Generalmovement.x, Generalmovement.y, 0f);

        playerAnimation.SetNextAnimationTrigger(AnimationHandler.AnimationState.Running);

        movePointCheker.position += offset;
    }

    public override void checkCollisions()
    {
        Collider2D collision = Physics2D.OverlapCircle(movePointCheker.position, .2f, whatstopMovmeet);

        if (currentPlayerFloorLevel == PlayerFloorLevel.Down)
        {
            if (collision)
            {
                movePointCheker.position = this.transform.position;
            }

        }
        else if (currentPlayerFloorLevel == PlayerFloorLevel.Up)
        {

            Collider2D[] collisionsArray = Physics2D.OverlapCircleAll(movePointCheker.position, .2f, whatstopMovmeet);

            bool colisionEnemigo = false;

            foreach (Collider2D collisionB in collisionsArray)
            {
                if (collisionB.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    colisionEnemigo = true;
                    break; // Terminamos la iteración si encontramos una colisión con un enemigo
                }
            }

            if (collisionsArray.Length == 0 || colisionEnemigo)
            {
                movePointCheker.position = this.transform.position;
            }

        }

    }

    public void ManageEnemieMovementIfAnotherEnemyMoveOnSameDirectionAndPlaceInfrontHim()
    {

        Collider2D[] collisionsArray = Physics2D.OverlapCircleAll(movePointCheker.position + offset, .2f, whatstopMovmeet);

        foreach (Collider2D collision in collisionsArray)
        {
            if (collision)
            {
                CheckCollisionAnotherZombieOnTheFront(collision);
            }
        }

    }

    public void ManageEnemiesOnSamePlace()
    {

        Collider2D[] collisionsArray = Physics2D.OverlapCircleAll(transform.position, .2f, whatstopMovmeet);

        foreach (Collider2D collision in collisionsArray)
        {
            if (collision)
            {
                if (collision.gameObject != gameObject)
                {
                    CheckCollisionAnotherZombieInSamePlace(collision);
                }
            }
        }

    }

    private void CheckCollisionAnotherZombieOnTheFront(Collider2D collision)
    {
        if (newcheckIfPlayerIsNOTStrillMoveent())
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null && currentPlayerFloorLevel == enemy.currentPlayerFloorLevel)
            {

                if (!enemy.newcheckIfPlayerIsNOTStrillMoveent())
                {
                    movePointCheker.position = enemy.transform.position;
                }

            }
        }
    }

    private void CheckCollisionAnotherZombieInSamePlace(Collider2D collision)
    {
        if (newcheckIfPlayerIsNOTStrillMoveent())
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                movePoint.position -= offset;
                
                if (GameManager.Instance.State == GameState.Gaming) { PlayerMovementsStored.reverseTheLastMovement(); }

            }
        }

    }

    protected override void HandleAnimationStateChanged(AnimationHandler.AnimationState state)
    {
        
    }

    public override bool CheckSwitchContactAndSetAnimation(string switchLayerName)
    {
        if (CkeckLayerContact(switchLayerName))
        {
            return true;
        }
        return false;
    }
}

