using Game.Scripts.Abstracts.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Scripts.Concretes.Inputs
{
    public class InputReaderHorizontal : IInputReader
    {
        public float Horizontal { get; set; }

        public InputReaderHorizontal()
        {
            GameInputActions input = new GameInputActions();
            input.Player.Move.performed += OnMovePerformed;
            input.Player.Move.canceled += OnMoveCanceled;
            input.Enable();
        }

        private void OnMoveCanceled(InputAction.CallbackContext context)
        {
            Horizontal = context.ReadValue<Vector2>().x;
        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            Horizontal = context.ReadValue<Vector2>().x;
        }
    }
}
