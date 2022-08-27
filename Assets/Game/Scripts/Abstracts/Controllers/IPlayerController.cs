using Game.Scripts.Abstracts.Inputs;

namespace Game.Scripts.Abstracts.Controllers
{
    public interface IPlayerController : IEntityController
    {
        IInputReader InputReader { get; set; }
        
    }
}