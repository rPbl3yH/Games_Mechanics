using Inventory.Components;
using Inventory.Equiper;
using Lessons.MetaGame.Inventory;
using NUnit.Framework;

public class EquipmentTest
{
    [Test]
    public void WhenAddBoots_ArrangeInventoryIsEmpty_ThenShouldViewNewBoots()
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


