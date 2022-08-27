using Game.Scripts.Abstracts.Controllers;
using Game.Scripts.Abstracts.Movement;
using UnityEngine;

namespace Game.Scripts.Concretes.Movement
{
    public class PlayerFlipScale : IFlip
    {
        private readonly IPlayerController _playerController;
        private readonly Transform _transform;

        public PlayerFlipScale(IPlayerController playerController)
        {
            _playerController = playerController;
            _transform = playerController.transform.GetChild(0).transform;
        }

        public void Tick()
        {
            if (_playerController.InputReader.Horizontal == 0f) return;
            _transform.localScale = Vector3.up + Vector3.right * _playerController.InputReader.Horizontal;
        }
    }
}