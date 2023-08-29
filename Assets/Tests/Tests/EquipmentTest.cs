using Elementary;
using Entities;
using Equipment.Core;
using Game.GameEngine.Mechanics;
using Inventory.Components;
using Inventory.EffectHandlers;
using Inventory.Equiper;
using Inventory.Player;
using Lessons.MetaGame.Inventory;
using NUnit.Framework;


public class EquipmentTest
{
    [Test]
    public void WhenAddLegs_ArrangeInventoryIsEmpty_ThenCheckLegsIsTrue()
    {
        //Arrange
        ListInventory listInventory = new ListInventory();
        var equipmentComponent = new EquipmentComponent
        {
            Type = EquipmentType.Legs
        };

        //Act
        listInventory.AddItem(new InventoryItem(
            "Boots",
            InventoryItemFlags.EQUPPABLE,
            new InventoryItemMetadata(),
            equipmentComponent
        ));
        
        //Assert
        bool isHaveLegs = listInventory.FindItem(EquipmentType.Legs, out var result);
        Assert.True(isHaveLegs);
    }

    [Test]
    public void WhenRemoveLegs_AndInventoryHasLegs_ThenAvailableItemIsEmpty()
    {
        //Arrange
        ListInventory listInventory = new ListInventory();
        
        var equipmentComponent = new EquipmentComponent
        {
            Type = EquipmentType.Legs
        };
        
        var item = new InventoryItem(
            "Boots",
            InventoryItemFlags.EQUPPABLE,
            new InventoryItemMetadata(),
            equipmentComponent
        );
        
        listInventory.AddItem(item); 
        
        //Act
        listInventory.RemoveItem(item);
        
        //Assert
        bool isHaveLegs = listInventory.FindItem(EquipmentType.Legs, out var result);
        Assert.False(isHaveLegs);
    }

    [Test]
    public void WhenGetItem_AndInventoryHasLegsAndEquipmentSystemIsEmpty_ThenEquip()
    {
        //Arrange
        ListInventory listInventory = new ListInventory();
        
        var equipmentComponent = new EquipmentComponent
        {
            Type = EquipmentType.Legs
        };
        
        var item = new InventoryItem(
            "Boots",
            InventoryItemFlags.EQUPPABLE,
            new InventoryItemMetadata(),
            equipmentComponent
        );
        listInventory.AddItem(item); 
        ListEquipment listEquipment = new ListEquipment();

        //Act
        InventoryItem legsItem = listInventory.GetItem(EquipmentType.Legs);

        //Assert
        listEquipment.Equip(EquipmentType.Legs, legsItem);
        Assert.True(true);
    }

    [Test]
    public void WhenEquipBoots_AndEquipmentIsEmpty_ThenLegsEqualsBoots()
    {
        //Arrange
        ListInventory listInventory = new ListInventory();
        
        var equipmentComponent = new EquipmentComponent
        {
            Type = EquipmentType.Legs
        };
        
        var item = new InventoryItem(
            "Boots",
            InventoryItemFlags.EQUPPABLE,
            new InventoryItemMetadata(),
            equipmentComponent
        );
        listInventory.AddItem(item); 
        ListEquipment listEquipment = new ListEquipment();
        
        InventoryItem legsItem = listInventory.GetItem(EquipmentType.Legs);

        //Act
        listEquipment.Equip(EquipmentType.Legs, legsItem);
        
        //Assert
        Assert.AreEqual(legsItem, listEquipment.GetItem(EquipmentType.Legs));
    }
    
    [Test]
    public void WhenEquipBoots_AndEquipmentIsEmpty_ThenAddDamage()
    {
        //Arrange
        ListInventory listInventory = new ListInventory();
        var listEquipment = new ListEquipment();
        InventoryItemEquipment inventoryItemEquipment = new InventoryItemEquipment(listEquipment, listInventory);
        var entity = Substitution.CreateComponent<TestEntity>();
        var effector = new Effector<IEffect>();
        var playerModel = Substitution.CreateComponent<PlayerModel>();
        entity.Add(new ComponentGetDamage(playerModel.Damage));
        entity.Add(new Component_Effector(effector));
        effector.AddHandler(new DamageEffectHandler(playerModel.Damage));
        var effectApplier = new EquipmentEffectApplier(entity, listEquipment);
        var config = UnityEditor.AssetDatabase.LoadAssetAtPath<InventoryItemConfig>(
            "Assets/Lesson_Inventory/Configs/InventoryItem (Boots).asset"
        );
        InventoryItem item = config.item.Clone();
        listInventory.AddItem(item);
        
        //Act
        inventoryItemEquipment.Equip(item);
        
        //Assert
        Assert.AreEqual(2f, playerModel.Damage.Value);
    }
    
    public class TestEntity : MonoEntityBase
    {
        
    }
}