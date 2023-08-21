using Entities;
using Equipment.Core;
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
            BindInventory();
            BindEquipment();
        }

        private void BindInventory()
        {
            Container.Bind<ListInventory>().AsSingle();
        }

        private void BindEquipment()
        {
            Container.Bind<ListEquipment>().AsSingle();
            Container.Bind<InventoryItemEquipment>().AsSingle();
            Container.Bind<EquipmentEffectApplier>().AsSingle();
        }
    }
}