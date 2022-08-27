using System;
using Game.Scripts.Abstracts.Controllers;
using Game.Scripts.Abstracts.Inputs;
using Game.Scripts.Abstracts.Movement;
using Game.Scripts.Concretes.Movement;
using UnityEngine;

namespace Game.Scripts.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        public IInputReader InputReader { get; set; }
        
        private IMover _mover;

        private void Awake()
        {
            _mover = new PlayerMovementTranslate(this);
        }

        private void Update()
        {
           _mover.Tick(); 
        }

        private void FixedUpdate()
        {
            _mover.FixedTick();
        }
    }
}
