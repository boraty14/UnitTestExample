using Game.Scripts.Abstracts.Controllers;
using Game.Scripts.Abstracts.Movement;
using UnityEngine;

namespace Game.Scripts.Concretes.Movement
{
    public class PlayerMovementTranslate : IMover
    {
        private float _moveSpeed = 1f;
        private float _horizontalInput = 0f;
        private readonly IPlayerController _playerController;
        private readonly Transform _transform;
        
        public PlayerMovementTranslate(IPlayerController playerController)
        {
            _playerController = playerController;
            _transform = playerController.transform;
        }
        
        public void Tick()
        {
            _horizontalInput = _playerController.InputReader.Horizontal;
        }

        public void FixedTick()
        {
            _transform.Translate(Vector2.right * _horizontalInput);
        }
    }
}
