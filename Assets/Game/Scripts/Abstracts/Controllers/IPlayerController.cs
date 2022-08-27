using Game.Scripts.Abstracts.Inputs;
using Game.Scripts.Abstracts.ScriptableObjects;

namespace Game.Scripts.Abstracts.Controllers
{
    public interface IPlayerController : IEntityController
    {
        IInputReader InputReader { get; set; }
        IPlayerStats Stats { get; }

    }
}