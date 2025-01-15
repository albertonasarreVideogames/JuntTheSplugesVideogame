using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public enum PlayerType
    {
        Type1,
        Type2,
        Type3,
        Type4,
        // Add more player types as needed
    }

    public enum PlayerFloorLevel
    {
        Down,
        Up,
        // Add more player types as needed
    }

    public Transform movePoint;
    public Transform movePointCheker;
    public float moveSpeed = 5f;

    public LayerMask whatstopMovmeet;

    public PlayerType playerType;

    public static PlayerType currentAllowedType = PlayerType.Type1;

    protected PlayerFloorLevel currentPlayerFloorLevel = PlayerFloorLevel.Down;

    protected Animator myAnimator;
    private bool facingRight = true;
    private AnimationHandler.IAnimationManager playerAnimation;

    private void Awake()
    {
        playerAnimation = GetComponent<AnimationHandler.IAnimationManager>();
        playerAnimation.OnAnimationStateChanged += HandleAnimationStateChanged;
    }

    private void OnDestroy()
    {
        playerAnimation.OnAnimationStateChanged -= HandleAnimationStateChanged;
    }
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        movePoint.parent = null;
        movePointCheker.parent = null;

        // orden de renderizado segun el typo de player, esto es para cuando se superponen

        float zPosition = -(float)(int)playerType;
        transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
        movePoint.position = new Vector3(movePoint.position.x, movePoint.position.y, zPosition);
        movePointCheker.position = new Vector3(movePointCheker.position.x, movePointCheker.position.y, zPosition);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (GetType() == typeof(Player) && checkIfPlayerIsNOTStrillMoveent() && Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) { myAnimator.SetBool("Run", false); } // este update hereda de enemy, habra que ponerle animacion tambien
    }

    public virtual bool CheckSwitchContactAndSetAnimation(string switchLayerName)
    {
        if (CkeckLayerContact(switchLayerName))
        {
           
            if(switchLayerName == "lava")
            {

                playerAnimation.SetNextAnimationTrigger(AnimationHandler.AnimationState.DieOnHole);

            } else {

                if (!newcheckIfPlayerIsNOTStrillMoveent())
                {

                    playerAnimation.SetNextAnimationTrigger(AnimationHandler.AnimationState.Attacking);

                }
            }
            
            return true;
        }
        return false;
    }

    public bool CkeckLayerContact(string layerName)
    {
        int layerIndex = LayerMask.NameToLayer(layerName);
        LayerMask layerMask = 1 << layerIndex;

        return Physics2D.OverlapCircle(movePointCheker.position, 0.2f, layerMask);
    }

    public virtual void updateMovepointChecker(Vector2 Generalmovement)
    {
        if (playerType == currentAllowedType)
        {
            movePointCheker.position += new Vector3(Generalmovement.x, Generalmovement.y, 0f);
            myAnimator.SetBool("Run", true);

            if (Generalmovement.x > 0 && !facingRight)
            {
                flip();
            }

            if (Generalmovement.x < 0 && facingRight)
            {
                flip();
            }
        }
    }

    // Pensar en mover esto a ScenarioConditionsUpdater
    public virtual void checkCollisions()
    {
        Collider2D collision = Physics2D.OverlapCircle(movePointCheker.position, .2f, whatstopMovmeet);

        if (currentPlayerFloorLevel == PlayerFloorLevel.Down)
        {
            if (collision)
            {
                movePointCheker.position = this.transform.position;
                if (checkIfPlayerIsNOTStrillMoveent()) { myAnimator.SetTrigger("Hit"); }
            }

        }
        else if (currentPlayerFloorLevel == PlayerFloorLevel.Up)
        {

            if (!collision)
            {
                movePointCheker.position = this.transform.position;
                if (checkIfPlayerIsNOTStrillMoveent()) { myAnimator.SetTrigger("Hit"); }
            }

        }

    }

    public void updateMovePoint()
    {
        if(playerAnimation.NextAnimationTrigger != AnimationHandler.AnimationState.AfterJump && playerAnimation.NextAnimationTrigger != AnimationHandler.AnimationState.DieOnHole) { 
        movePoint.position = movePointCheker.position;
        }
    }

    public void updatecheckMovePoint()
    {
        movePointCheker.position = transform.position;
    }

    public bool checkIfPlayerIsNOTStrillMoveent()
    {
        bool isAtMovePoint = Vector3.Distance(transform.position, movePoint.position) == 0;
        bool isAnimationFinished = IsAnimationFinished("Enemy Attack 1", 1.0f);
        bool isAnimationFinished2 = IsAnimationFinished("Enemy Hit", 0.7f);

        return isAtMovePoint && isAnimationFinished && isAnimationFinished2;
    }

    private bool IsAnimationFinished()
    {
        if (myAnimator == null) return true;

        AnimatorStateInfo stateInfo = myAnimator.GetCurrentAnimatorStateInfo(0);

        // Comprobar que no está en un estado de animación o que la animación ha terminado
        return stateInfo.normalizedTime >= 1.0f && !myAnimator.IsInTransition(0);
    }

 

    private bool IsAnimationFinished(string animationName, float limitToReinice)
    {
        if (myAnimator == null) return true;

        // Si el Animator está en transición, devolvemos false
        if (myAnimator.IsInTransition(0))
        {
            return false;
        }

        AnimatorStateInfo stateInfo = myAnimator.GetCurrentAnimatorStateInfo(0);

        // Si la animación activa no es la que esperamos, devolvemos true
        if (!stateInfo.IsName(animationName))
        {
            return true;
        }

        // Comprobar si la animación ha llegado al final
        bool hasFinished = stateInfo.normalizedTime >= limitToReinice;

        return hasFinished;
    }

    public bool newcheckIfPlayerIsNOTStrillMoveent()
    {
        return Vector3.Distance(transform.position, movePointCheker.position) <= .05f;
    }

    public static void changePlayerTypeToMove()
    {
        currentAllowedType = GetNextPlayerType();
    }

    public void ChangeFloorLevel(PlayerFloorLevel playerFloorLevel)
    {
        currentPlayerFloorLevel = playerFloorLevel;
    }

    private static PlayerType GetNextPlayerType()
    {
        int currentTypeIndex = (int)currentAllowedType;
        int nextTypeIndex = (currentTypeIndex + 1) % MapLoader.Instance.NumberKindPlayers;

        return (PlayerType)nextTypeIndex;
    }

    protected virtual void HandleAnimationStateChanged(AnimationHandler.AnimationState state)
    {
        // updateMovePoint() detecta si ya si son alguna de estas dos animaciones, ya que en ese casi es esta funcion quien se encarga de moverlas
        switch (state)
        {
            case AnimationHandler.AnimationState.AfterJump:
                movePoint.position = movePointCheker.position;
                break;

            case AnimationHandler.AnimationState.DieOnHole:
                movePoint.position = movePointCheker.position;
                break;
        }
        
    }

    private void flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }


}
