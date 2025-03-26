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
    public LayerMask whatstopMovmeetBorder;

    public PlayerType playerType;

    public static PlayerType currentAllowedType = PlayerType.Type1;

    protected PlayerFloorLevel currentPlayerFloorLevel = PlayerFloorLevel.Down;

    protected Animator myAnimator;
    protected bool facingRight = true;
    protected AnimationHandler.IAnimationManager playerAnimation;
    public MovementsManagerPlay PlayerMovementsStored;

    private void Awake()
    {
        playerAnimation = GetComponent<AnimationHandler.IAnimationManager>();
        playerAnimation.OnAnimationStateChanged += HandleAnimationStateChanged;
        PlayerMovementsStored = new MovementsManagerPlay();
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
    }

    // Update is called once per frame
    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        if (checkIfPlayerIsNOTStrillMoveent() && Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) { myAnimator.SetBool("Run", false); }
    }

    public virtual bool CheckSwitchContactAndSetAnimation(string switchLayerName)
    {

        if (CkeckLayerContact(switchLayerName))
        {
      
            if (switchLayerName == "lava")
            {

                playerAnimation.SetNextAnimationTrigger(AnimationHandler.AnimationState.DieOnHole);

                if (CheckTagContact("Pincho") || CheckTagContact("GreenPincho") || CheckTagContact("PinkPincho") || CheckTagContact("BluePincho"))
                {
                    playerAnimation.SetNextAnimationTrigger(AnimationHandler.AnimationState.Electricity);
                }

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

    private bool CheckTagContact(string tagName)
    {

        Collider2D[] hits = Physics2D.OverlapCircleAll(movePointCheker.position, 0.2f, Physics2D.AllLayers);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag(tagName))
            {
                return true; // Se encontró un objeto con la tag especificada
            }
        }

        return false; // No se encontró ningún objeto con la tag
    }

    public virtual void updateMovepointChecker(Vector2 Generalmovement)
    {
        if (playerType == currentAllowedType)
        {
            movePointCheker.position += new Vector3(Generalmovement.x, Generalmovement.y, 0f);
            playerAnimation.SetNextAnimationTrigger(AnimationHandler.AnimationState.Running);
        

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

    public virtual void updateMovepointCheckerToRewind()
    {

        Vector2 Generalmovement = PlayerMovementsStored.getButtonOnLastPosition();
        movePointCheker.position += new Vector3(Generalmovement.x, Generalmovement.y, 0f);
        playerAnimation.SetNextAnimationTrigger(AnimationHandler.AnimationState.Running);


        if (Generalmovement.x > 0 && facingRight)
        {
            flip();
        }

        if (Generalmovement.x < 0 && !facingRight)
        {
            flip();
        }

    }

    // Pensar en mover esto a ScenarioConditionsUpdater
    public virtual void checkCollisions()
    {
        Collider2D collisionBorder = Physics2D.OverlapCircle(movePointCheker.position, .2f, whatstopMovmeetBorder);

        if (collisionBorder)
        {
            movePointCheker.position = this.transform.position;
            if (checkIfPlayerIsNOTStrillMoveent()) { playerAnimation.SetNextAnimationTrigger(AnimationHandler.AnimationState.hit); }
            return;
        }

        Collider2D collision = Physics2D.OverlapCircle(movePointCheker.position, .2f, whatstopMovmeet);

        if (currentPlayerFloorLevel == PlayerFloorLevel.Down)
        {
            if (collision)
            {
                movePointCheker.position = this.transform.position;
                if (checkIfPlayerIsNOTStrillMoveent()) { playerAnimation.SetNextAnimationTrigger(AnimationHandler.AnimationState.hit); }
            }

        }
        else if (currentPlayerFloorLevel == PlayerFloorLevel.Up)
        {

            if (!collision)
            {
                movePointCheker.position = this.transform.position;
                if (checkIfPlayerIsNOTStrillMoveent()) { playerAnimation.SetNextAnimationTrigger(AnimationHandler.AnimationState.hit); }
            }

        }

        

    }

    public void updateMovePoint()
    {
        if(playerAnimation.NextAnimationTrigger != AnimationHandler.AnimationState.AfterJump && playerAnimation.NextAnimationTrigger != AnimationHandler.AnimationState.DieOnHole) { 
            movePoint.position = movePointCheker.position;
            Vector2 movement = movePointCheker.position - this.transform.position;
            
            if (GameManager.Instance.State == GameState.Gaming) { PlayerMovementsStored.addMovement(movement); }
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

 

    protected bool IsAnimationFinished(string animationName, float limitToReinice)
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
                Vector2 movement = movePointCheker.position - this.transform.position;
                if (GameManager.Instance.State == GameState.Gaming) { PlayerMovementsStored.addMovement(movement);}
                movePoint.position = movePointCheker.position;
                break;

            case AnimationHandler.AnimationState.DieOnHole:
                Vector2 movement2 = movePointCheker.position - this.transform.position;
                if (GameManager.Instance.State == GameState.Gaming) { PlayerMovementsStored.addMovement(movement2);}
                movePoint.position = movePointCheker.position;
                break;
        }
        
    }

    protected void flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public void ExecuteAnimation(string animation) {

        myAnimator.SetTrigger(animation);
    }

    public void setnextAnimation(AnimationHandler.AnimationState state)
    {

        playerAnimation.SetNextAnimationTrigger(state);
    }

    public AnimationHandler.AnimationState getnextAnimation()
    {

        return playerAnimation.NextAnimationTrigger;
    }


}
