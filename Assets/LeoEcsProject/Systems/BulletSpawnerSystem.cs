using LeoEcs.Systems;
using LeoEcsHomeTask.Views;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace LeoEcsHomeTask.Systems
{
    public class BulletSpawnerSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<DamageComponent, ViewComponent, ColorComponent, TeamComponent>> _bulletFilter;
        private readonly EcsFilterInject<Inc<BulletSpawnComponent>> _bulletSpawnFilter;
        private readonly EcsPoolInject<HealthComponent> _healthPool;
        private readonly EcsPoolInject<BulletSpawnComponent> _bulletPool;
        private readonly EcsCustomInject<UnitData> _unitData;
        private readonly EcsCustomInject<BulletData> _bulletData;
        private readonly EcsWorldInject _world;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _bulletSpawnFilter.Value)
            {
                ref var bulletSpawn = ref _bulletPool.Value.Get(entity);
                var bulletEntity = _world.Value.NewEntity();
                ref var damage = ref _bulletFilter.Pools.Inc1.Add(bulletEntity);
                ref var view = ref _bulletFilter.Pools.Inc2.Add(bulletEntity);
                ref var color = ref _bulletFilter.Pools.Inc3.Add(bulletEntity);
                ref var team = ref _bulletFilter.Pools.Inc4.Add(bulletEntity);
                ref var health = ref _healthPool.Value.Add(bulletEntity);
                
                ref var unitTeam = ref _bulletFilter.Pools.Inc4.Get(bulletSpawn.SourceEntity);
                team.IsRed = unitTeam.IsRed;

                ref var unitView = ref _bulletFilter.Pools.Inc2.Get(bulletSpawn.SourceEntity);
                ref var targetUnitView = ref _bulletFilter.Pools.Inc2.Get(bulletSpawn.TargetEntity);
                
                damage.DamageValue = _bulletData.Value.Damage;
                health.Health = _bulletData.Value.Health;

                var position = unitView.View.transform.position;
                var bullet = Object.Instantiate(
                    Resources.Load<EcsMonoObject>(_bulletData.Value.Path),
                    position,
                    Quaternion.LookRotation(targetUnitView.View.transform.position - position)
                );
                
                bullet.Init(_world.Value);
                bullet.PackEntity(bulletEntity);

                view.View = bullet.gameObject;
                
                ref var unitColor = ref _bulletFilter.Pools.Inc3.Get(bulletSpawn.SourceEntity);
                color.Renderer = bullet.gameObject.GetComponent<MeshRenderer>();
                color.Renderer.material.color = unitColor.Renderer.material.color;
                
                _world.Value.DelEntity(entity);
            }
        }
    }
}