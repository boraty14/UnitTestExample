using Game.Scripts.Abstracts.Controllers;
using Game.Scripts.Abstracts.Inputs;
using Game.Scripts.Abstracts.Movement;
using Game.Scripts.Concretes.Movement;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

public class player_movement_editor
{
    private IPlayerController GetPlayer()
    {
        IPlayerController playerController = Substitute.For<IPlayerController>();
        GameObject gameObject = new GameObject();
        playerController.transform.Returns(gameObject.transform);
        playerController.InputReader = Substitute.For<IInputReader>();
        return playerController;
    }

    private IMover GetMoverTranslate(IPlayerController playerController)
    {
        IMover mover = new PlayerMovementTranslate(playerController);
        return mover;
    }


    [Test]
    [TestCase(1f)]
    [TestCase(-1f)]
    public void moveHorizontal10Units_notEqualsStartPosition(float horizontalInput)
    {
        //Arrange
        var playerController = GetPlayer();
        var mover = GetMoverTranslate(playerController);
        Vector3 startPosition = playerController.transform.position;

        //Act
        playerController.InputReader.Horizontal.Returns(horizontalInput);
        for (int i = 0; i < 10; i++)
        {
            mover.Tick(); // input 
            mover.FixedTick(); // act with input
        }

        //Assert
        Assert.AreNotEqual(startPosition, playerController.transform.position);
    }
}