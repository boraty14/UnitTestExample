using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class first_play_test
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator first_play_testWithEnumeratorPasses()
    {
        // Arrange
        int firstNumber = 10;
        int secondNumber = 20;
        int expectedResult = 30;

        // Act
        int result = firstNumber + secondNumber;

        // Assert
        Assert.AreEqual(expectedResult, result);
        yield return null;
    }


    [UnityTest]
    public IEnumerator createNewObject_findOnScene()
    {
        // Arrange
        string name = "NewObject";
        GameObject newObject = new GameObject(name);
        

        // Act
        GameObject foundObject = GameObject.Find(name);
        
        // Assert
        Assert.AreSame(foundObject,newObject);
        yield return null;
    }
}