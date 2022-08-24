using NUnit.Framework;

public class first_editor_test_script
{
    // edit mode test
    [Test]
    public void Add_FirstNumber_SecondNumber()
    {
        // Arrange
        int firstNumber = 10;
        int secondNumber = 20;
        int expectedResult = 30;

        // Act
        int result = firstNumber + secondNumber;

        // Assert
        Assert.AreEqual(expectedResult,result);
    }

    // play mode test
    // [UnityTest]
    // public IEnumerator first_editor_test_scriptWithEnumeratorPasses()
    // {
    //     yield return null;
    // }
}
