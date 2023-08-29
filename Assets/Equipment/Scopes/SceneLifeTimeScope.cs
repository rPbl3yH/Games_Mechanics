using Entities;
using Equipment.Core;
using Inventory.Equiper;
using Lessons.MetaGame.Inventory;
using VContainer;
using VContainer.Unity;

public class SceneLifeTimeScope : LifetimeScope
{

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<MonoEntity>().As(typeof(IEntity));

        builder.RegisterInstance(new ListInventory());

        builder.Register<ListEquipment>(Lifetime.Singleton);
        builder.Register<InventoryItemEquipment>(Lifetime.Singleton);
        builder.Register<EquipmentEffectApplier>(Lifetime.Singleton);
    }

    //public override void InstallBindings()
    //{
    //    Container.Bind<IEntity>().FromComponentInHierarchy().AsSingle();
    //    BindInventory();
    //    BindEquipment();
    //}

    //private void BindInventory()
    //{
    //    Container.Bind<ListInventory>().AsSingle();
    //}

    //private void BindEquipment()
    //{
    //    Container.Bind<ListEquipment>().AsSingle();
    //    Container.Bind<InventoryItemEquipment>().AsSingle();
    //    Container.Bind<EquipmentEffectApplier>().AsSingle();
    //}
}
