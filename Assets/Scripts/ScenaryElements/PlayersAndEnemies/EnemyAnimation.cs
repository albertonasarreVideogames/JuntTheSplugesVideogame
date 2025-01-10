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

    public void executetriggeranimations()
    {
        //throw new System.NotImplementedException();
    }

    public void SetNextAnimationTrigger(AnimationHandler.AnimationState newState)
    {
        //throw new System.NotImplementedException();
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
