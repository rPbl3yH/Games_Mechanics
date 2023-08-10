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
        public AnimatorStateMachine<AnimationStateType> _animatorStateMachine = new();

        [Construct]
        public void Construct(HeroDocument heroDocument, HeroStates heroStates)
        {
            var coreFSM = heroStates.StateMachine;

            _animatorStateMachine.AddTransition(AnimationStateType.Idle, () => coreFSM.CurrentStateType == HeroStateType.Idle);
            _animatorStateMachine.AddTransition(AnimationStateType.Run, () => coreFSM.CurrentStateType == HeroStateType.Run);
            _animatorStateMachine.AddTransition(AnimationStateType.Shoot, () => heroDocument.Core.FireSection.IsFire.Value);
            _animatorStateMachine.AddTransition(AnimationStateType.Death, () => coreFSM.CurrentStateType == HeroStateType.Dead);
        }
    }
}