using LeoEcs.Systems;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace LeoEcsHomeTask.Systems
{
    public class DamageComponentSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<DamageComponent, ViewComponent, TeamComponent>> _bulletFilter;
        private readonly EcsFilterInject<Inc<HitComponent>> _hitFilter;
        private readonly EcsPoolInject<HealthComponent> _healthPool;
        private readonly EcsWorldInject _world;
        
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _hitFilter.Value)
            {
                ref var hit = ref _hitFilter.Pools.Inc1.Get(entity);

                (int, int) hitEntities = PackerEntityUtils.UnpackEntities(_world.Value, hit.BulletView.PackedEntity,
                    hit.UnitView.PackedEntity);

                ref var bulletTeam = ref _bulletFilter.Pools.Inc3.Get(hitEntities.Item1);
                ref var unitTeam = ref _bulletFilter.Pools.Inc3.Get(hitEntities.Item2);

                if (bulletTeam.IsRed != unitTeam.IsRed)
                {
                    ref var bulletDamage = ref _bulletFilter.Pools.Inc1.Get(hitEntities.Item1);
                    ref var unitHealth = ref _healthPool.Value.Get(hitEntities.Item2);
                    ref var bulletHealth = ref _healthPool.Value.Get(hitEntities.Item1);
                    
                    unitHealth.Health -= bulletDamage.DamageValue;
                    bulletHealth.Health = 0;
                }

                _world.Value.DelEntity(entity);
            }
        }
    }
}