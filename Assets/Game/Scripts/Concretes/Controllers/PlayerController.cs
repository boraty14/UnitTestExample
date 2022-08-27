using Game.Scripts.Abstracts.Controllers;
using Game.Scripts.Abstracts.Inputs;
using UnityEngine;

namespace Game.Scripts.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        public IInputReader InputReader { get; set; }
    }
}
