using Entities;
using Inventory.Equiper;
using Lessons.MetaGame.Inventory;
using Zenject;

namespace Inventory.Installers
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