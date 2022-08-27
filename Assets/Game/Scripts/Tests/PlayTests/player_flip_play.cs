using System.Collections;
using System.Collections.Generic;
using Game.Scripts.Abstracts.Controllers;
using Game.Scripts.Abstracts.Inputs;
using Game.Scripts.Concretes.Controllers;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class player_flip_play
{
    [UnityTest]
    [TestCase(1f, ExpectedResult = (IEnumerator) null)]
    [TestCase(-1f, ExpectedResult = (IEnumerator) null)]
    public IEnumerator flipTest_scaleEqualsItself(float horizontalInput)
    {
        // Arrange
        yield return SceneManager.LoadSceneAsync("PlayerMovementTest");
        IPlayerController playerController = GameObject.FindObjectOfType<PlayerController>();
        playerController.InputReader = Substitute.For<IInputReader>();
        
        // Act
        playerController.InputReader.Horizontal.Returns(horizontalInput);
        yield return new WaitForSeconds(1f);

        // Assert
        Assert.AreEqual(playerController.transform.GetChild(0).localScale.x,horizontalInput);
    }
}
