using System;
using Declarative;
using StateMachine.States;
using UnityEngine;

namespace AtomicProject.Hero
{
	[Serializable]
    public class HeroVisual
    {
        [Section] 
        public HeroAnimationStates HeroAnimationStates;
    }
}