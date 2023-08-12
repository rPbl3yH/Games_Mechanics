using System;
using Entities;
using Game.GamePlay.Conveyor.Components;
using UnityEngine;

namespace Game.GamePlay.Conveyor
{
    public class ConveyorEntity : MonoEntityBase
    {
        [SerializeField] private ConveyorModel _model;
        
        private void Awake()
        {
            Add(new Conveyor_LoadComponent(_model.LoadStorageCapacity));            
        }
    }
}