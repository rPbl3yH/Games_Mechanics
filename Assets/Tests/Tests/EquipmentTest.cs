using System.Collections;
using Game.GameEngine.Mechanics;
using Inventory.Components;
using Lessons.MetaGame.Inventory;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EquipmentTest
{
    [UnityTest]
    public IEnumerator EquipmentBoots()
    {
        //Arrange
        var gameObject = new GameObject();
        var inventoryContext = gameObject.AddComponent<InventoryContext>();
        var config = UnityEditor.AssetDatabase.LoadAssetAtPath<InventoryItemConfig>(
            "Assets/Lesson_Inventory/Configs/InventoryItem (Boots).asset"
            );
        
        //Act
        inventoryContext.AddItem(config);
        Debug.Log("Add Item ");
        
        //Assert

        yield return null;
    }
}
