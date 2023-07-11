﻿using System;

namespace LeoEcs.Systems
{
    [Serializable]
    public class SharedData
    {
        public int BorderX;
        public int BorderZ;

        public int SpawnCount;
        public string Path;

        public int Health;
        public int Damage;

        public int Speed;
    }

    [Serializable]
    public class SharedBlueData : SharedData
    {
        
    }

    [Serializable]
    public class SharedRedData : SharedData
    {
        
    }
}