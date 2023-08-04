using System;
using AtomicProject.Hero.Animation;
using Declarative;
using StateMachine;
using StateMachine.States;
using UnityEngine;

namespace AtomicProject.Hero
{
    [Serializable]
    public class HeroVisual
    {
        public Animator Animator;

        [Section] 
        public HeroAnimationStates HeroAnimationStates;
    }

    [Serializable]
    public class HeroAnimationStates
    {
        public AnimationStateMachine<AnimationStateType> _animationStateMachine = new();

        [Construct]
        public void Construct(HeroStates heroStates)
        {
            //TODO: construct states
            // _animationStateMachine.Construct(
            //     (AnimationStateType.Idle, null),
            //     (AnimationStateType.Run, null),
            //     (AnimationStateType.Shoot, null),
            //     (AnimationStateType.Death, null)
            //     );
            //
            // var coreFSM = heroStates.StateMachine;
            //
            // _animationStateMachine.AddTransition(AnimationStateType.Idle, () => coreFSM.CurrentStateType == HeroStateType.Idle);
            // _animationStateMachine.AddTransition(AnimationStateType.Run, () => coreFSM.CurrentStateType == HeroStateType.Run);
            // _animationStateMachine.AddTransition(AnimationStateType.Shoot, () => coreFSM.CurrentStateType == HeroStateType.Shoot);
            // _animationStateMachine.AddTransition(AnimationStateType.Death, () => coreFSM.CurrentStateType == HeroStateType.Dead);
            //
        }
    }
}