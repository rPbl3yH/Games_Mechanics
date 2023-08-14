using Entities;
using Lessons.MetaGame.Inventory;
using Zenject;

namespace Game
{
    public class GameSystemInstaller : MonoInstaller<GameSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IEntity>().FromComponentInHierarchy().AsSingle();
            Container.Bind<InventoryItemEquiper>().FromNew().AsSingle();
            Container.BindInterfacesAndSelfTo<InventoryContext>().FromComponentInHierarchy().AsSingle();
        }
    }
}