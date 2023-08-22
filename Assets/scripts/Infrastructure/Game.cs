using System.Threading.Tasks;
using Infrastructure.GameStateMachineModule;

namespace Infrastructure
{
    public class Game
    {
        private readonly GameStateMachine _stateMachine;
            
        public Game()
        {
            _stateMachine = new GameStateMachine();
        }

        public async Task Initialize()
        {
            await _stateMachine.Enter<BootstrapState>();
            //await _stateMachine.Enter<MainMenuState>();
        }
    }
}