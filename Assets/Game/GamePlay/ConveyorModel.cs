using System.Collections;
using System.Collections.Generic;
using Declarative;
using Game.App.Atomic.Values;
using UnityEngine;

public class ConveyorModel : DeclarativeModel
{
    public AtomicVariable<int> LoadStorageCapacity;
    public AtomicVariable<int> UnloadStorageCapacity;
    public AtomicVariable<float> ProduceTime;
}
