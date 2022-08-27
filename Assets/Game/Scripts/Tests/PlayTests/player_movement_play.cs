using System.Collections;
using Game.Scripts.Abstracts.Controllers;
using Game.Scripts.Abstracts.Inputs;
using Game.Scripts.Concretes.Controllers;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class player_movement_play
{
    private IPlayerController _playerController;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        yield return LoadPlayerMovementTestScene();
        _playerController = GameObject.FindObjectOfType<PlayerController>();
        _playerController.InputReader = Substitute.For<IInputReader>();
    }

    private IEnumerator LoadPlayerMovementTestScene()
    {
        yield return SceneManager.LoadSceneAsync("PlayerMovementTest");
    }

    [UnityTest]
    [TestCase(1f, ExpectedResult = (IEnumerator) null)]
    [TestCase(-1f, ExpectedResult = (IEnumerator) null)]
    public IEnumerator playerMoveHorizontal_notEqualStartPosition(float horizontalInput)
    {
        // Arrange
        Vector3 startPosition = _playerController.transform.position;

        // Act
        _playerController.InputReader.Horizontal.Returns(horizontalInput);
        yield return new WaitForSeconds(3f);

        // Assert
        Assert.AreNotEqual(startPosition, _playerController.transform.position);
    }
    
}