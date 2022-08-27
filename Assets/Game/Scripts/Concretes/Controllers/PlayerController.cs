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

        private void Awake()
        {
            InputReader = new InputReaderHorizontal();
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
