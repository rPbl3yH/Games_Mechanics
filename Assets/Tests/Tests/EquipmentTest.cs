using Inventory.Components;
using Lessons.MetaGame.Inventory;
using NUnit.Framework;

public class EquipmentTest
{
    [Test]
    public void WhenAddBoots_ArrangeInventoryIsEmpty_ThenShouldViewNewBoots()
    {
        //Arrange
        ListInventory listInventory = new ListInventory();
        EquipObserver equipObserver = new EquipObserver(listInventory);

        //Act
        listInventory.AddItem(new InventoryItem(
            "Boots",
            InventoryItemFlags.EQUPPABLE,
            new InventoryItemMetadata(),
            new EquipmentComponent()
            ));
        
        //Assert
        bool isHaveBoots = equipObserver.Check("Boots");
        Assert.True(isHaveBoots);
    }
    
    public class EquipObserver
    {
        private readonly ListInventory _listInventory;

        public EquipObserver(ListInventory listInventory)
        {
            _listInventory = listInventory;
        }

        public bool Check(string name)
        {
            return _listInventory.FindItem(name, out InventoryItem result);
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


