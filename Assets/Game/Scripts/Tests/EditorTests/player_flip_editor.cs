using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using Game.Scripts.Abstracts.Controllers;
using Game.Scripts.Abstracts.Movement;
using Game.Scripts.Concretes.Movement;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

public class player_flip_editor
{
    [Test]
    [TestCase(1f)]
    [TestCase(-1f)]
    public void flipTestRight_scaleEqualsItself(float horizontalInput)
    {
        // Arrange
        IPlayerController playerController = Substitute.For<IPlayerController>();
        GameObject parent = new GameObject();
        GameObject body = new GameObject();
        body.transform.SetParent(parent.transform, true);
        playerController.transform.Returns(parent.transform);
        IFlip flip = new PlayerFlipScale(playerController);

        // Act
        playerController.InputReader.Horizontal.Returns(horizontalInput);
        for (int i = 0; i < 10; i++)
        {
            flip.Tick();
        }

        // Assert
        Assert.AreEqual(horizontalInput, body.transform.localScale.x);
    }
}