using System.Collections;
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
        gameObject.AddComponent<InventoryContext>();
        
        //Act
        //Assert

        yield return null;
        Assert.True(true);
    }
}
