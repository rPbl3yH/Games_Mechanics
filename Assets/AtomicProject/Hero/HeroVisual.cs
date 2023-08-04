using System;
using AtomicProject.Hero.Animation;
using StateMachine;
using UnityEngine;

namespace AtomicProject.Hero
{
    [Serializable]
    public class HeroVisual
    {
        
        public Animator Animator;
    }

    public class HeroAnimationStates
    {
        public AnimationStateMachine<AnimationStateType> _animationStateMachine;
    }
}