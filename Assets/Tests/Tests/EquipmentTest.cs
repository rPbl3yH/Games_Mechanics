using System.Collections;
using Entities;
using Game.GameEngine.Mechanics;
using Inventory.Components;
using Inventory.Equiper;
using Inventory.Player;
using Lessons.MetaGame.Inventory;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EquipmentTest
{
    public class TestEntity : MonoEntityBase
    {
            
    }
    
    [UnityTest]
    public IEnumerator WhenAddBoots_ArrangeInventoryIsEmpty_ThenBootsShouldBeEquip()
    {
        //Arrange
        var gameObject = new GameObject();
        var inventory = new ListInventory();
        var config = UnityEditor.AssetDatabase.LoadAssetAtPath<InventoryItemConfig>(
            "Assets/Lesson_Inventory/Configs/InventoryItem (Boots).asset"
            );

        var model = gameObject.AddComponent<PlayerModel>();
        var entity = gameObject.AddComponent<TestEntity>();
        var component = new ComponentEquipItem(model.Equipments);
        entity.Add(component);
        var inventoryItemEquiper = new InventoryItemEquiper(entity);
        inventory.AddObserver(inventoryItemEquiper);
        
        //Act
        inventory.AddItem(config.item.Clone());
        Debug.Log("Add Item " + config != null);
        Debug.Log(model.Equipments.Count);
        
        //Assert
        if (model.Equipments.TryGetValue(EquipmentType.Legs, out var item))
        {
            Debug.Log($"{config.item.Name} and {item.Name}");
            Assert.AreEqual(config.item.Name, item.Name);
        }
        else
        {
            Assert.Fail();
        }

        yield return null;
    }
}
