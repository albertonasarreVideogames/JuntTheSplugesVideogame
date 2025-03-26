using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour, AnimationHandler.IAnimationManager
{
    public static List<PlayerAnimation> AllPlayersAnimation = new List<PlayerAnimation>();

    public bool animationFinished = false;
    private AnimationHandler.AnimationState _nextAnimationTrigger;

    public AnimationHandler.AnimationState NextAnimationTrigger
    {
        get => _nextAnimationTrigger;
        set => _nextAnimationTrigger = value;
    }
    private Animator myAnimator;

    public event AnimationHandler.AnimationEventHandler OnAnimationStateChanged;
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        AllPlayersAnimation.Add(this);
    }

    private void OnDestroy()
    {
        AllPlayersAnimation.Remove(this);
    }

    public void SetNextAnimationTrigger(AnimationHandler.AnimationState newState)
    {
        if (NextAnimationTrigger == newState) return;

        NextAnimationTrigger = newState;
    }

    public void OnAttackAnimationStart()
    {
        // Llamado por un evento en la animación de ataque
        //SetNextAnimationTrigger(AnimationHandler.AnimationState.Idle);
        OnAnimationStateChanged?.Invoke(AnimationHandler.AnimationState.AfterJump);
    }

    public void OnAttackAnimationAlmostEnd()
    {
       foreach (var animation in AllPlayersAnimation)
       {
          if (animation.NextAnimationTrigger == AnimationHandler.AnimationState.Dying) {

              animation.myAnimator.SetTrigger("Death");
           };
       }

        if (NextAnimationTrigger == AnimationHandler.AnimationState.DieOnHole) { myAnimator.SetTrigger("fallInHole"); SetNextAnimationTrigger(AnimationHandler.AnimationState.Idle); SoundManager.PlaySoundONCE(SoundType.SPLINGEFALLING); }
        if (NextAnimationTrigger == AnimationHandler.AnimationState.AfterJump) { SetNextAnimationTrigger(AnimationHandler.AnimationState.Idle); }

    }

    public void executetriggeranimations()
    {
        switch (NextAnimationTrigger)
        {
            case AnimationHandler.AnimationState.Attacking:
                myAnimator.SetTrigger("Attack");
                SetNextAnimationTrigger(AnimationHandler.AnimationState.AfterJump);
                SoundManager.AddSoundToNextTurn(SoundType.SPUNGEJUMP);
                break;

            case AnimationHandler.AnimationState.DieOnHole:
                myAnimator.SetTrigger("Attack");
                SetNextAnimationTrigger(AnimationHandler.AnimationState.DieOnHole);
                SoundManager.AddSoundToNextTurn(SoundType.SPUNGEJUMP);
                break;

            case AnimationHandler.AnimationState.Running:
                myAnimator.SetBool("Run", true);
                SetNextAnimationTrigger(AnimationHandler.AnimationState.Idle);                          
                SoundManager.AddSoundToNextTurn(SoundType.SPLUNGESRUN);                         
                break;

            case AnimationHandler.AnimationState.hit:
                myAnimator.SetTrigger("Hit");
                SetNextAnimationTrigger(AnimationHandler.AnimationState.Idle);               
                SoundManager.AddSoundToNextTurn(SoundType.SPLUGEHITONWALL);   
                break;
            case AnimationHandler.AnimationState.Electricity:
                myAnimator.SetTrigger("Attack 2");
                SetNextAnimationTrigger(AnimationHandler.AnimationState.Idle);
                SoundManager.AddSoundToNextTurn(SoundType.SPUNGEJUMP);
                break;


        }

    }

    public static void SetAnimationForAllPlayers(AnimationHandler.AnimationState animationState, Func<PlayerAnimation, bool> condition = null)
    {
        foreach (var playerAnimation in AllPlayersAnimation)
        {
            if (condition == null || condition(playerAnimation))
            {
                playerAnimation.SetNextAnimationTrigger(animationState);

            }
        }
    }

}
