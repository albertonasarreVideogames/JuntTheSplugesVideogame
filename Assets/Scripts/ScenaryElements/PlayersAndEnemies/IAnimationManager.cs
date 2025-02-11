using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationHandler
{
    public delegate void AnimationEventHandler(AnimationState state);

    public enum AnimationState
    {
        Idle,
        Running,
        Attacking,
        Dying,
        Winning,
        AfterJump,
        DieOnHole,
        hit
    }

    public interface IAnimationManager
    {
        event AnimationEventHandler OnAnimationStateChanged;
        AnimationState NextAnimationTrigger { get; }
        void SetNextAnimationTrigger(AnimationState newState);
        void executetriggeranimations();
    }
}
