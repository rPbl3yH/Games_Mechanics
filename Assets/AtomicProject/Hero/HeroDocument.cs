using Declarative;
using UnityEngine;

namespace AtomicProject.Hero
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
