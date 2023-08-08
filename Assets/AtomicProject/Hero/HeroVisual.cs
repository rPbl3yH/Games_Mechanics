using System;
using Declarative;
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
}