using Declarative;
using UnityEngine;

namespace AtomicHomework.Hero
{
    public class HeroDocument : DeclarativeModel
    {
        public Transform Transform;

        [Section]
        public HeroCore Core;

        [Section]
        public HeroVisual Visual;
    }
}
