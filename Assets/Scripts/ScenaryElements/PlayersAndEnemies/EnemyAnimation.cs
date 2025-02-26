using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour, AnimationHandler.IAnimationManager
{
    private AnimationHandler.AnimationState _nextAnimationTrigger;
    public AnimationHandler.AnimationState NextAnimationTrigger
    {
        get => _nextAnimationTrigger;
        set => _nextAnimationTrigger = value;
    }

    public event AnimationHandler.AnimationEventHandler OnAnimationStateChanged;
    private Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void executetriggeranimations()
    {
        switch (NextAnimationTrigger)
        {        
            case AnimationHandler.AnimationState.Running:
                myAnimator.SetBool("Run", true);
                SetNextAnimationTrigger(AnimationHandler.AnimationState.Idle);             
                break;
            case AnimationHandler.AnimationState.Attacking:
                myAnimator.SetTrigger("Attack");
                SoundManager.AddSoundToNextTurn(SoundType.ENEMYBITE);
                SetNextAnimationTrigger(AnimationHandler.AnimationState.Idle);
                break;
        }
    }

    public void SetNextAnimationTrigger(AnimationHandler.AnimationState newState)
    {
        if (NextAnimationTrigger == newState) return;

        NextAnimationTrigger = newState;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
