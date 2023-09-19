using System.Threading.Tasks;
using GameLogic;
using Infrastructure.EventBusModule;
using Infrastructure.GameStateMachineModule;
using Infrastructure.GameStateMachineModule.States;
using Infrastructure.ServiceLocatorModule;

namespace Infrastructure
{
    public class Game
    {
        private readonly GameStateMachine _stateMachine;
        private EventBus _eventBus;
        public Game()
        {
            _stateMachine = new GameStateMachine();
            _eventBus = new EventBus();
            ServiceLocator.Instance.Register(_eventBus);
            
            _eventBus.Subscribe(EventBusDefinitions.HimselfGameSelected, OnHimselfSelected);
        }

        private void OnHimselfSelected(EventBusArgs args)
        {
            HimselfAgainstHimselfGame game = new HimselfAgainstHimselfGame();
        }

        public async Task Initialize()
        {
            await _stateMachine.Enter<BootstrapState>();
            await _stateMachine.Enter<MainMenuState>();
        }
        
        
    }
}