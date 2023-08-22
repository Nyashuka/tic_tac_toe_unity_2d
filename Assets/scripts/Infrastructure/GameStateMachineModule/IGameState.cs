using System.Threading.Tasks;

namespace Infrastructure.GameStateMachineModule
{
    public interface IGameState
    {
        Task Enter();
        Task Exit();
    }
}