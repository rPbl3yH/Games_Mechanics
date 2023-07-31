﻿using AtomicHomework.Entities.Components;
using AtomicHomework.Services;
using UnityEngine;
using Zenject;

namespace AtomicHomework.Input
{
    public class FireInputController : MonoBehaviour
    {
        [Inject] private HeroService _heroService;
        
        private void Update()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                if (_heroService.GetHero().TryGet(out IFireComponent fireComponent))
                {
                    fireComponent.Fire();
                }
            }
        }
    }
}