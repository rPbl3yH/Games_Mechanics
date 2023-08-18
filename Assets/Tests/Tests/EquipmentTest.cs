using Inventory.Components;
using Inventory.Equiper;
using Lessons.MetaGame.Inventory;
using NUnit.Framework;


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
        bool canEquip = listEquipment.Equip(legsItem);
        Assert.True(canEquip);
    }
}


