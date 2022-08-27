using Game.Scripts.Abstracts.Controllers;
using Game.Scripts.Abstracts.Inputs;
using Game.Scripts.Abstracts.Movement;
using Game.Scripts.Concretes.Movement;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

public class player_movement
{
    [Test]
    public void moveLeft10Units_notEqualStartPosition()
    {
        //Arrange
        IPlayerController playerController = Substitute.For<IPlayerController>();
        GameObject gameObject = new GameObject();
        playerController.transform.Returns(gameObject.transform);
        playerController.InputReader = Substitute.For<IInputReader>();
        IMover mover = new PlayerMovementTranslate(playerController);
        Vector3 startPosition = playerController.transform.position;

        //Act
        playerController.InputReader.Horizontal.Returns(1f);
        for (int i = 0; i < 10; i++)
        {
            mover.Tick(); // input 
            mover.FixedTick(); // act with input
        }

        //Assert
        Assert.AreNotEqual(startPosition, playerController.transform.position);
    }


    [Test]
    public void moveLeft10Units_equalEndPosition()
    {
        //Arrange
        IPlayerController playerController = Substitute.For<IPlayerController>();
        GameObject gameObject = new GameObject();
        playerController.transform.Returns(gameObject.transform);
        playerController.InputReader = Substitute.For<IInputReader>();
        IMover mover = new PlayerMovementTranslate(playerController);

        //Act
        playerController.InputReader.Horizontal.Returns(1f);
        for (int i = 0; i < 10; i++)
        {
            mover.Tick(); // input 
            mover.FixedTick(); // act with input
        }

        //Assert
        Assert.AreEqual(new Vector3(10,0,0), playerController.transform.position);
    }
}