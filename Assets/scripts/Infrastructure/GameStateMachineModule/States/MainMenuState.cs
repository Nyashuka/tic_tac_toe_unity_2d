using System.Threading.Tasks;
using Infrastructure.ServiceLocatorModule;
using Services;
using Object = UnityEngine.Object;

namespace Infrastructure.GameStateMachineModule.States
{
    public class MainMenuState : IGameState
    {
        public async Task Enter()
        {
            AssetsProvider assetsProvider = ServiceLocator.Instance.GetService<AssetsProvider>();
            
            Object.Instantiate(assetsProvider.UIAssets.UIController);
        }

        public async Task Exit()
        {
            
        }
    }
}