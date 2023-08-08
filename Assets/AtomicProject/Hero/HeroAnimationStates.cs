using System;
using AtomicProject.Hero.Animation;
using Declarative;
using StateMachine;
using StateMachine.States;

namespace AtomicProject.Hero
{
	[Serializable]
    public class HeroAnimationStates
    {
        public AnimationStateMachine<AnimationStateType> _animationStateMachine = new();

        [Construct]
        public void Construct(HeroDocument heroDocument, HeroStates heroStates)
        {
            var coreFSM = heroStates.StateMachine;

            _animationStateMachine.AddTransition(AnimationStateType.Idle, () => coreFSM.CurrentStateType == HeroStateType.Idle);
            _animationStateMachine.AddTransition(AnimationStateType.Run, () => coreFSM.CurrentStateType == HeroStateType.Run);
            _animationStateMachine.AddTransition(AnimationStateType.Shoot, () => coreFSM.CurrentStateType == HeroStateType.Shoot);
            _animationStateMachine.AddTransition(AnimationStateType.Death, () => coreFSM.CurrentStateType == HeroStateType.Dead);
        }
    }
}