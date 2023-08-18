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
        BootsChecker bootsChecker = new BootsChecker();
        listInventory.AddListener(bootsChecker);
        var equipmentComponent = new EquipmentComponent();
        equipmentComponent.Type = EquipmentType.Legs;
        
        //Act
        listInventory.AddItem(new InventoryItem(
            "Boots",
            InventoryItemFlags.EQUPPABLE,
            new InventoryItemMetadata(),
            equipmentComponent
            ));
        
        //Assert
        bool isHaveBoots = bootsChecker.Check();
        Assert.True(isHaveBoots);
    }
    
    public class BootsChecker : IInventoryListener
    {
        private EquipmentType _equipmentType;
        private bool _isHaveBoots;
        
        public bool Check()
        {
            return _isHaveBoots;
        }

        public void OnItemAdded(InventoryItem item)
        {
            if (item.Flags.HasFlag(InventoryItemFlags.EQUPPABLE))
            {
                if (item.GetComponent<EquipmentComponent>().Type == EquipmentType.Legs)
                {
                    _isHaveBoots = true;
                }
            }
        }

        public void OnItemRemoved(InventoryItem item)
        {
            
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


