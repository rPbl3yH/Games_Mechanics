using Entities;
using Inventory.Equiper;
using Zenject;

namespace Equipment.Core
{
    public class EquipmentInstaller : MonoInstaller<EquipmentInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ListEquipment>().AsSingle();
            Container.Bind<InventoryItemEquipment>().AsSingle();
            Container.Bind<EquipmentEffectApplier>().AsSingle();
        }
    }
}