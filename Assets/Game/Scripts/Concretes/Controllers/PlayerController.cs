using System;
using Game.Scripts.Abstracts.Controllers;
using Game.Scripts.Abstracts.Inputs;
using Game.Scripts.Abstracts.Movement;
using Game.Scripts.Abstracts.ScriptableObjects;
using Game.Scripts.Concretes.Inputs;
using Game.Scripts.Concretes.Movement;
using Game.Scripts.Concretes.ScriptableObjects;
using UnityEngine;

namespace Game.Scripts.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        public IInputReader InputReader { get; set; }
        public IPlayerStats Stats => _playerStats;

        [SerializeField] private PlayerStats _playerStats;
        private IMover _mover;
        private IFlip _flip;

        private void Awake()
        {
            InputReader = new InputReaderHorizontal();
            _mover = new PlayerMovementTranslate(this);
            _flip = new PlayerFlipScale(this);
        }

        private void Update()
        {
           _mover.Tick(); 
           _flip.Tick();
        }

        private void FixedUpdate()
        {
            _mover.FixedTick();
        }
    }
}
