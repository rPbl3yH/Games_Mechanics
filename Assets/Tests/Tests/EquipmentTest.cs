using Entities;
using Game.GameEngine.Mechanics;
using Inventory.Components;
using Inventory.Equiper;
using Inventory.Player;
using Lessons.MetaGame.Inventory;
using NUnit.Framework;
using UnityEngine;


public class EquipmentEffectApplier
{
    private ListEquipment _listEquipment;
    private IEntity _character;
    
    public EquipmentEffectApplier(IEntity character, ListEquipment listEquipment)
    {
        _listEquipment = listEquipment;
        _listEquipment.OnEquipped += OnEquipped;
        _character = character;
    }

    private void OnEquipped(InventoryItem item)
    {
        if (IsEffectible(item))
        {
            var effect = GetEffect(item);
            _character.Get<IComponent_Effector>().Apply(effect);
        }
    }

    private static IEffect GetEffect(InventoryItem item)
    {
        return item.GetComponent<IComponent_GetEffect>().Effect;
    }
    
    private static bool IsEffectible(InventoryItem item)
    {
        return item.Flags.HasFlag(InventoryItemFlags.EFFECTIBLE);
    }
}

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
}