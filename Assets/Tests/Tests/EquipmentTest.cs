using Elementary;
using Entities;
using Game.GameEngine.Mechanics;
using Inventory.Components;
using Inventory.EffectHandlers;
using Inventory.Equiper;
using Inventory.Player;
using Lessons.MetaGame.Inventory;
using NUnit.Framework;
using UnityEngine;


public class EquipmentTest
{
    [Test]
    public void WhenAddLegs_ArrangeInventoryIsEmpty_ThenCheckLegsIsTrue()
    {
        //Arrange
        ListInventory listInventory = new ListInventory();
        EquipmentService equipmentService = new EquipmentService();
        listInventory.AddListener(equipmentService);
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
        bool isHaveLegs = equipmentService.CheckItem(EquipmentType.Legs);
        Assert.True(isHaveLegs);
    }

    [Test]
    public void WhenRemoveLegs_AndInventoryHasLegs_ThenAvailableItemIsEmpty()
    {
        //Arrange
        ListInventory listInventory = new ListInventory();
        EquipmentService equipmentService = new EquipmentService();
        listInventory.AddListener(equipmentService);
        
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
        bool isHaveLegs = equipmentService.CheckItem(EquipmentType.Legs);
        Assert.False(isHaveLegs);
    }

    [Test]
    public void WhenGetItem_AndInventoryHasLegsAndEquipmentSystemIsEmpty_ThenEquip()
    {
        //Arrange
        ListInventory listInventory = new ListInventory();
        EquipmentService equipmentService = new EquipmentService();
        listInventory.AddListener(equipmentService);
        
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
        InventoryItem legsItem = equipmentService.GetItem(EquipmentType.Legs);

        //Assert
        bool isEquip = listEquipment.Equip(legsItem);
        Assert.True(isEquip);
    }

    [Test]
    public void WhenEquipBoots_AndEquipmentIsEmpty_ThenLegsEqualsBoots()
    {
        //Arrange
        ListInventory listInventory = new ListInventory();
        EquipmentService equipmentService = new EquipmentService();
        listInventory.AddListener(equipmentService);
        
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
        InventoryItem legsItem = equipmentService.GetItem(EquipmentType.Legs);

        //Act
        listEquipment.Equip(legsItem);
        
        //Assert
        Assert.AreEqual(legsItem, listEquipment.GetItem(EquipmentType.Legs));
    }

    public class TestEntity : MonoEntityBase
    {
        
    }
    [Test]
    public void WhenEquipBoots_AndEquipmentIsEmpty_ThenAddDamage()
    {
        //Arrange
        var listEquipment = new ListEquipment();
        var entity = Substitution.CreateComponent<TestEntity>();
        var effector = new Effector<IEffect>();
        var playerModel = Substitution.CreateComponent<PlayerModel>();
        entity.Add(new ComponentGetDamage(playerModel.Damage));
        entity.Add(new Component_Effector(effector));
        effector.AddHandler(new DamageEffectHandler(playerModel.Damage));
        var effectApplier = new EquipmentEffectApplier(entity, listEquipment);
        
        //Act
        var config = UnityEditor.AssetDatabase.LoadAssetAtPath<InventoryItemConfig>(
            "Assets/Lesson_Inventory/Configs/InventoryItem (Boots).asset"
            );
        InventoryItem item = config.item.Clone();
        listEquipment.Equip(item);
        
        //Assert
        Assert.AreEqual(2f, playerModel.Damage.Value);
    }
}

public static class Substitution
{
    public static T CreateComponent<T>() where T : Component
    {
        return new GameObject().AddComponent<T>();
    }
}