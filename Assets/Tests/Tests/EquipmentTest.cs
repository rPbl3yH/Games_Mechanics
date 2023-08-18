using System.Collections.Generic;
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
    public void WhenGetItem_AndInventoryHasLegsAndEquipmentSystemIsEmpty_ThenCanEquip()
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
        
        EquipmentController equipmentController = new EquipmentController();

        //Act
        InventoryItem legsItem = equipmentService.GetItem(EquipmentType.Legs);

        //Assert
        bool canEquip = equipmentController.CanEquip(legsItem);
        Assert.True(canEquip);
    }
    
    
    public class EquipmentController
    {
        public bool CanEquip(InventoryItem legsItem)
        {
            return true;
        }
    }

    
    // public class TestEntity : MonoEntityBase
    // {
    //         
    // }
    //
    // [UnityTest]
    // public IEnumerator WhenAddBoots_ArrangeInventoryIsEmpty_ThenBootsShouldBeEquip()
    // {
    //     //Arrange
    //     var gameObject = new GameObject();
    //     var inventory = new ListInventory();
    //     var config = UnityEditor.AssetDatabase.LoadAssetAtPath<InventoryItemConfig>(
    //         "Assets/Lesson_Inventory/Configs/InventoryItem (Boots).asset"
    //         );
    //
    //     var model = gameObject.AddComponent<PlayerModel>();
    //     var entity = gameObject.AddComponent<TestEntity>();
    //     var component = new ComponentEquipItem(model.Equipments);
    //     entity.Add(component);
    //     var inventoryItemEquiper = new InventoryItemEquiper(entity);
    //     inventory.AddObserver(inventoryItemEquiper);
    //     
    //     //Act
    //     inventory.AddItem(config.item.Clone());
    //     Debug.Log("Add Item " + config != null);
    //     Debug.Log(model.Equipments.Count);
    //     
    //     //Assert
    //     if (model.Equipments.TryGetValue(EquipmentType.Legs, out var item))
    //     {
    //         Debug.Log($"{config.item.Name} and {item.Name}");
    //         Assert.AreEqual(config.item.Name, item.Name);
    //     }
    //     else
    //     {
    //         Assert.Fail();
    //     }
    //
    //     yield return null;
    // }
}


